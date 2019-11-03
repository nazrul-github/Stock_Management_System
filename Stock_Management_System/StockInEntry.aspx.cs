using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stock_Management_System.MODELS;

namespace Stock_Management_System
{
    public partial class StockInEntry : System.Web.UI.Page
    {
        Company company = new Company();
        Items items = new Items();
        StockIn stockin = new StockIn();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCompany.DataTextField = "CompanyName";
                ddlCompany.DataValueField = "CompanyID";
                ddlCompany.DataSource = company.ShowCompanies();
                ddlCompany.DataBind();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int companyId = Convert.ToInt32(ddlCompany.SelectedValue);
                int itemsId = Convert.ToInt32(ddlItem.SelectedValue);
                int stockInQuantity = Convert.ToInt32(stockInTextBox.Text);
                msgLabel.Text = stockin.SaveStockIn(companyId, itemsId, stockInQuantity);
                msgLabel.ForeColor = Color.Green;

                ddlItem.SelectedIndex = 0;
                ddlCompany.SelectedIndex = 0;
                reorderLabel.Text = String.Empty;
                quantityLabel.Text = string.Empty;
            }
            else
            {
                msgLabel.Text = "Validation failed!!! Please check all the input";
                msgLabel.ForeColor = Color.Red;
            }
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            msgLabel.Text = String.Empty;
            quantityLabel.Text = String.Empty;
            reorderLabel.Text = string.Empty;
            ddlItem.ClearSelection();
            ddlItem.DataSource = null;
            ddlItem.DataBind();
            ddlItem.DataTextField = "ItemName";
            ddlItem.DataValueField = "ItemId";
            ddlItem.DataSource = items.GetItem(Convert.ToInt32(ddlCompany.SelectedValue));
            ddlItem.DataBind();
            ddlItem.Items.Insert(0, new ListItem("--Please select a item--", "0"));
        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Items aItem = new Items();
            aItem = items.GetAItem(Convert.ToInt32( ddlItem.SelectedValue));
            quantityLabel.Text = aItem.Quantity.ToString();
            reorderLabel.Text = aItem.ReorderLabel.ToString();
        }

       
    }
}