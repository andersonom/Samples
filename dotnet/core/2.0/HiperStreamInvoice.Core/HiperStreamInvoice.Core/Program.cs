using System;
using System.Collections.Generic;
using System.IO;
using FluentValidation;
using FluentValidation.Results;
using System.Text;
using System.Diagnostics;
using System.Globalization;

namespace HiperStreamInvoice.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            IInvoice _invoice;
            _invoice = new Invoice();
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
    }

    public class CSVWriter : IFileWriter<Invoice>
    {
        public void WriteFiles(List<Invoice> list, string fileName)
        {
            StringBuilder sb = new StringBuilder(); sb.AppendLine("NomeCliente; EnderecoCompleto; ValorFatura; NumeroPaginas;");

            for (int x = 0; x < list.Count; x++)
            {
                sb.AppendFormat("{0};{1};{2};{3}", list[x].ClientName, list[x].Street, list[x].InvoiceValue, list[x].PageQutd).AppendLine();
            }

            var filePath = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            File.WriteAllText(String.Format("{0}//{1}", filePath, fileName), sb.ToString());
        }
    }

    public class Invoice : IInvoice
    {
        public String ClientName { get; set; }
        public String PostalCode { get; set; }
        public String Street { get; set; }
        public String District { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String InvoiceValue { get; set; }
        public int PageQutd { get; set; }

        IFileWriter<Invoice> _fileWriter;

        public Invoice()
        {
            _fileWriter = new CSVWriter();
        }

        public int Process(string fileName)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string description = string.Empty;
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

                while ((description = reader.ReadLine()) != null)
                {
                    try
                    {
                        string[] values = description.Split(';');

                        inv = new Invoice
                        {
                            ClientName = values[0].Trim(),
                            PostalCode = values[1].Trim(),
                            Street = values[2].Trim(),
                            District = values[3].Trim(),
                            City = values[4].Trim(),
                            State = values[5].Trim(),
                            InvoiceValue = values[6].Trim(),
                            PageQutd = Convert.ToInt32(values[7].Trim())
                        };

                        ValidationResult results = validator.Validate(inv);
                        bool validationSucceeded = results.IsValid;

                        if (validationSucceeded)
                        {
                            inv.PageQutd = validator.ForceEvenNumber(inv.PageQutd);
                            if (Decimal.Parse(inv.InvoiceValue, CultureInfo.InvariantCulture) <= 0)
                                listZeroInvoiceValue.Add(inv);
                            else if (inv.PageQutd < 7)
                                listSmall.Add(inv);
                            else if (inv.PageQutd < 13)
                                listMed.Add(inv);
                            else if (inv.PageQutd > 12)
                                listBig.Add(inv);
                        }
                        else
                        {
                            ConsoleUtility.WriteErrors(description, results);
                            errorCount++;
                        }
                    }
                    catch (Exception ex)
                    {
                        ConsoleUtility.WriteException(description, ex);
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
        string _countryCode;
        public InvoiceValidator(string countryCode = "BR")
        {
            string _countryCode = countryCode;
        }        

        public InvoiceValidator()
        {
            RuleFor(invoice => invoice.ClientName).NotEmpty().WithMessage("Nome vazio"); ;
            RuleFor(invoice => invoice.PostalCode).Must(BeAValidPostalCode).WithMessage("Cep Inválido");
            RuleFor(invoice => invoice.Street).Length(5, 250).WithMessage("RuaComComplemento deve ser maior que 5 e menor que 250"); ;
            RuleFor(invoice => invoice.District).NotEmpty().WithMessage("Bairro vazio");
            RuleFor(invoice => invoice.City).NotEmpty().WithMessage("Cidade vazia");
            RuleFor(invoice => invoice.State).NotEmpty().WithMessage("Estado vazio");
            RuleFor(invoice => invoice.PageQutd).NotEqual(0);
        }

        private bool BeAValidPostalCode(string postalCode)
        {             
            if (_countryCode == "BR")
            {
                if (postalCode.Length == 8)
                    postalCode = postalCode.Substring(0, 5) + "-" + postalCode.Substring(5, 3);

                if (postalCode == "00000-000" || postalCode == "99999-999")
                    return false;
                else
                    return System.Text.RegularExpressions.Regex.IsMatch(postalCode, ("[0-9]{5}-[0-9]{3}"));
            }
            else
                throw new Exception("Country Postal Code validation not yet implemented!");

        }

        public int ForceEvenNumber(int page)
        {
            if (page % 2 != 0)
                return page + 1;
            else
                return page;
        }
    }

    public static class ConsoleUtility
    {
        public static void WriteException(string description, Exception ex)
        {
            Console.WriteLine(description);
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine(string.Empty);
        }

        public static void WriteErrors(string description, ValidationResult results)
        {
            foreach (var item in results.Errors)
            {
                Console.WriteLine(String.Format("Linha inválida: {0}", description));
                Console.WriteLine(String.Format("Mensagem: {0}", item.ErrorMessage));
                Console.WriteLine(string.Empty);
            }
        }
    }
}

