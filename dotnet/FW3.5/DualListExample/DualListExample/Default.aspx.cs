using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DualListExample
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ListPicker1.DataSource = new ListItemCollection() { "Cat", "Rabbit" };
                ListPicker1.DataBind();
                ListPicker1.AddSourceItem("Dog");
                ListPicker1.AddSourceItem("Rat");               
            }            
        }
    }
}
