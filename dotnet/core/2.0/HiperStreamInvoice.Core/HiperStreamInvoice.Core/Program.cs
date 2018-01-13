using System;
using System.Collections.Generic;
using System.IO;
using FluentValidation;
using FluentValidation.Results;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using System.Threading;

namespace HiperStreamInvoice.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            IInvoice _invoice;
            _invoice = new Invoice(); //Poderia usar a injeção automática do .net core ou ninject
            _invoice.Process(@"Baseficticia.txt");
        }
    }

    public interface IInvoice
    {
        int Process(string fileName);
    }

    public interface IFileWriter<T> where T : class
    {
        void WriteFiles(List<T> list, string fileName);
        void WriteException(string line, Exception ex);
        void WriteErrors(string line, ValidationResult results);
    }

    public class CSVWriter : IFileWriter<Invoice>
    {
        public void WriteFiles(List<Invoice> list, string fileName)
        {
            StringBuilder sb = new StringBuilder(); sb.AppendLine("NomeCliente; EnderecoCompleto; ValorFatura; NumeroPaginas;");

            for (int x = 0; x < list.Count; x++)
            {
                sb.AppendFormat("{0};{1};{2};{3}", list[x].NomeCliente, list[x].RuaComComplemento, list[x].ValorFatura, list[x].NumeroPaginas).AppendLine();
            }

            var filePath = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            File.WriteAllText(String.Format("{0}//{1}", filePath, fileName), sb.ToString());
        }

        public void WriteException(string line, Exception ex)//Poderia estar em outra classe
        {
            Console.WriteLine(line);
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine(string.Empty);
        }

        public void WriteErrors(string line, ValidationResult results)//Poderia estar em outra classe
        {
            foreach (var item in results.Errors)
            {
                Console.WriteLine(String.Format("Linha inválida: {0}", line));
                Console.WriteLine(String.Format("Mensagem: {0}", item.ErrorMessage));
                Console.WriteLine(string.Empty);
            }
        }
    }

    public class Invoice : IInvoice
    {
        public String NomeCliente { get; set; }
        public String CEP { get; set; }
        public String RuaComComplemento { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public String ValorFatura;

        public int NumeroPaginas { get; set; }

        IFileWriter<Invoice> _fileWriter;

        public Invoice()
        {
            _fileWriter = new CSVWriter();//Poderia usar a injeção automática do .net core ou ninject
        }

        public int Process(string fileName)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string line = string.Empty;
            int errorCount = 0;
            Invoice inv;
            InvoiceValidator validator = new InvoiceValidator();

            List<Invoice> listZeroInvoiceValue = new List<Invoice>();
            List<Invoice> listSmall = new List<Invoice>();
            List<Invoice> listMed = new List<Invoice>();
            List<Invoice> listBig = new List<Invoice>();

            using (var reader = new StreamReader(fileName))
            {
                string headerLine = reader.ReadLine();//skip header

                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        string[] values = line.Split(';');

                        inv = new Invoice
                        {
                            NomeCliente = values[0].Trim(),
                            CEP = values[1].Trim(),
                            RuaComComplemento = values[2].Trim(),
                            Bairro = values[3].Trim(),
                            Cidade = values[4].Trim(),
                            Estado = values[5].Trim(),
                            ValorFatura = values[6].Trim(),
                            NumeroPaginas = Convert.ToInt32(values[7].Trim())
                        };

                        ValidationResult results = validator.Validate(inv);
                        bool validationSucceeded = results.IsValid;

                        if (validationSucceeded)
                        {
                            inv.NumeroPaginas = validator.ForceEvenNumber(inv.NumeroPaginas);
                            if (Decimal.Parse(inv.ValorFatura, CultureInfo.InvariantCulture) <= 0)
                                listZeroInvoiceValue.Add(inv);
                            else if (inv.NumeroPaginas < 7)
                                listSmall.Add(inv);
                            else if (inv.NumeroPaginas < 13)
                                listMed.Add(inv);
                            else if (inv.NumeroPaginas > 12)
                                listBig.Add(inv);
                        }
                        else
                        {
                            _fileWriter.WriteErrors(line, results);
                            errorCount++;
                        }
                    }
                    catch (Exception ex)
                    {
                        _fileWriter.WriteException(line, ex);
                    }
                }
            }

            _fileWriter.WriteFiles(listZeroInvoiceValue, "FaturasZeradas.csv");
            _fileWriter.WriteFiles(listSmall, "FaturasAte6Paginas.csv");
            _fileWriter.WriteFiles(listMed, "FaturasAte12Paginas.csv");
            _fileWriter.WriteFiles(listBig, "FaturasComMaisDe12Paginas.csv");

            sw.Stop();
            int regCount = errorCount + listBig.Count + listMed.Count + listSmall.Count + listZeroInvoiceValue.Count;

            Console.WriteLine(String.Format("Tempo decorrido: {0}", sw.Elapsed));
            Console.WriteLine(String.Format("Total de Erros: {0}", errorCount));
            Console.WriteLine(String.Format("Total de Registros lidos: {0}", regCount));

            return regCount;
        }
    }

    public class InvoiceValidator : AbstractValidator<Invoice>
    {
        public InvoiceValidator()
        {
            RuleFor(invoice => invoice.NomeCliente).NotEmpty().WithMessage("Nome vazio"); ;
            RuleFor(invoice => invoice.CEP).Must(BeAValidCep).WithMessage("Cep Inválido");
            RuleFor(invoice => invoice.RuaComComplemento).Length(5, 250).WithMessage("RuaComComplemento deve ser maior que 5 e menor que 250"); ;
            RuleFor(invoice => invoice.Bairro).NotEmpty().WithMessage("Bairro vazio");
            RuleFor(invoice => invoice.Cidade).NotEmpty().WithMessage("Cidade vazia");
            RuleFor(invoice => invoice.Estado).NotEmpty().WithMessage("Estado vazio");
            RuleFor(invoice => invoice.NumeroPaginas).NotEqual(0);
        }

        private bool BeAValidCep(string cep)
        {
            if (cep.Length == 8)
                cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);

            if (cep == "00000-000" || cep == "99999-999")
                return false;
            else
                return System.Text.RegularExpressions.Regex.IsMatch(cep, ("[0-9]{5}-[0-9]{3}"));
        }

        public int ForceEvenNumber(int page)
        {
            if (page % 2 != 0)
                return page + 1;
            else
                return page;
        }
    }
}

