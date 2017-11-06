using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MVPSampleBLL.Model
{
    internal class XMLManager
    {
        private string myXml = string.Empty;

        public XMLManager(string xmlFilename)
        {
            myXml = xmlFilename;
        }

        /// <summary>Lê o arquivo XML passado como parâmetro no construtor da classe.</summary>
        /// <returns>Um DataSet contendo todo o conteúdo do arquivo.</returns>
        public DataSet GetAppData()
        {
            DataSet myData = null;

            try
            {
                myData = new DataSet();
                //Lê o arquivo XML
                myData.ReadXml(myXml);
            }

            catch (Exception ex)
            {
                throw new Exception(string.Format("Ocorreu um problema ao ler o arquivo de dados. Verifique se o caminho [{0}] corresponde ao arquivo físico.", myXml), ex);
            }

            return myData;

        }



        /// <summary>Insere um novo registro no XML.</summary>
        /// <param name="name">Nome do alimento a ser inserido.</param>
        /// <param name="price">Preço do alimento a ser inserido.</param>
        /// <param name="description">Descrição do alimento a ser inserido.</param>
        /// <param name="calories">Quantidade de calorias do alimento a ser inserido.</param>
        public void InsertRow(string name, string price, string description, string calories)
        {
            DataSet myData = null;

            try
            {
                //Cria um instância de um objeto DataSet
                myData = new DataSet();
                //Lê o arquivo XML
                myData.ReadXml(myXml);
                //Adiciona uma linha na tabela food com os valores informados.
                myData.Tables["food"].
                Rows.Add(name, price, description, calories);
                //Escreve o XML com o novo registro, substituindo o anterior.
                myData.WriteXml(myXml);
            }

            catch (Exception ex)
            {
                throw new Exception(string.Format("Ocorreu um problema ao ler o arquivo de dados. Verifique se o caminho[{0}] corresponde ao arquivo físico.", myXml), ex);
            }
        }
    }
}
