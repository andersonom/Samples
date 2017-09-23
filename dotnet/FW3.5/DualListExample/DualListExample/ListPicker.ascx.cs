using DualListExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListPicker
{
    public partial class ListPicker : System.Web.UI.UserControl
    {
        public Boolean AllowDuplicates
        {
            get { return (Boolean)Session["allowDuplicates"]; }
            set { Session["allowDuplicates"] = value; }
        }

        public ListItemCollection SelectedItems
        {
            get { return ListBoxTargetList.Items; }
        }

        public ListItemCollection DataSource
        {
            get { return ListBoxSourceList.Items; }
            set { ListBoxSourceList.DataSource = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                AllowDuplicates = false;
                Session["ListItems"] = new List<string>();
            }
        }

        protected void ButtonAddAll_Click(object sender, EventArgs e)
        {
            ListBoxTargetList.SelectedIndex = -1;
            foreach (ListItem li in ListBoxSourceList.Items)
            {
                AddItem(li.ToString());
            }
        }

        protected void ButtonRemoveAll_Click(object sender, EventArgs e)
        {
            ListBoxSourceList.SelectedIndex = -1;

            (Session["ListItems"] as List<string>).RemoveAll((string s) => s.Length > 1);

            Bind();
        }

        protected void ButtonAddOne_Click(object sender, EventArgs e)
        {
            if (ListBoxSourceList.SelectedIndex >= 0)
            {
                AddItem(ListBoxSourceList.SelectedItem.ToString());
            }
        }

        protected void ButtonRemoveOne_Click(object sender, EventArgs e)
        {
            if (ListBoxTargetList.SelectedIndex >= 0)
            {
                RemoveItem(ListBoxTargetList.SelectedItem.ToString());
            }
        }

        private void AddItem(string li)
        {
            ListBoxTargetList.SelectedIndex = -1;

            var listItemns = Session["ListItems"] as List<string>;

            if (this.AllowDuplicates == true)
            {
                (listItemns).Add(li);
                Bind();
            }
            else
            {
                if (!listItemns.Contains(li))
                {
                    listItemns.Add(li);
                    Bind();
                }
            }
        }
        private void Bind()
        {
            ListBoxTargetList.DataSource = Session["ListItems"] as List<string>;
            ListBoxTargetList.DataBind();
        }

        private void RemoveItem(string li)
        {
            (Session["ListItems"] as List<string>).Remove(li);
            ListBoxTargetList.SelectedIndex = -1;
            Bind();
        }

        public void AddSourceItem(String sourceItem)
        {
            ListBoxSourceList.Items.Add(sourceItem);
        }
    }
}