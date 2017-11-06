using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPSampleBLL.Model;
using MVPSampleBLL.Interface;
using System.Data;

namespace MVPSampleBLL.Presenter
{
    public class FoodPresenter
    {
        private IFood view; //Interface

        private DataSet dsFood;

        private XMLManager data;//Model

        /// <summary>Construtor da classe.</summary>
        /// <param name="view">Classe que implementa a Interface IFood.</param>
        public FoodPresenter(IFood view)
        {
            try
            {
                this.view = view;
                //Cria uma instânciada classe XMLManager
                data = new XMLManager(view.XMLFilePath);
            }

            catch 
            {
                throw;
            }
        }

        public void InsertRow()
        {
            try
            {
                //Insere um novo registro no XML
                data.InsertRow(view.NameFood, view.Price, view.Description, view.Calories);
                BindGrid();
            }

            catch 
            {
                throw;
            }
        }

        public void BindGrid()
        {
            try
            {
                //Obtém uma nova listagem dos dados do XML
                dsFood = data.GetAppData();
                //Atualiza a propriedade BindGrid do objeto passado como parâmetro no construtor.
                view.BindGrid = dsFood;
            }

            catch 
            {
                throw;
            }
        } 
    }
}
