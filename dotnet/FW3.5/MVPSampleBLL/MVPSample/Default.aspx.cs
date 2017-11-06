using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MVPSampleBLL.Presenter;
using MVPSampleBLL.Interface;
using System.Configuration;
namespace MVPSample
{
    public partial class _Default : System.Web.UI.Page, IFood
    {
        FoodPresenter presenter = null;
        string xmlFilePath = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Recupera o caminho correto do arquivo de dados XML. O nome do arquivo é configurado no arquivo web.config na chave XMLFileName
            XMLFilePath = string.Concat(HttpContext.Current.Request.MapPath("."), "\\", "App_Data", "\\", ConfigurationManager.AppSettings["XMLFileName"]);

            //Cria uma intância do objeto FoodPresenter passando como referência a página em questão, já que ela implementa a Interface IFood
            presenter = new FoodPresenter(this);

            if (!IsPostBack)
            {//Faz a carga inicial do Grid.
                presenter.BindGrid();
            }
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        { //Insere um novo registro no XML
            presenter.InsertRow();
        }


        #region IFoodView Members
        public DataSet BindGrid
        {
            set
            {
                GridFood.DataSource = value;
                GridFood.DataBind();
            }
        }

        public string NameFood
        {
            get
            {
                return txtName.Text;
            }
        }

        public string Price
        {
            get
            {
                return txtPrice.Text;
            }
        }

        public string Description
        {
            get
            {
                return txtDescription.Text;
            }
        }

        public string Calories
        {
            get
            {
                return txtCalories.Text;
            }
        }

        public string XMLFilePath
        {
            get
            {
                return xmlFilePath;
            }
            set
            {
                xmlFilePath = value;
            }
        }
        #endregion

       
    }

}


