using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stock_Management_System.MODELS;

namespace Stock_Management_System
{
    public partial class StockOutRecord : System.Web.UI.Page
    {
        Company company = new Company();
        Items items = new Items();
        StockOut stockOut = new StockOut();
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
        protected void addButton_Click(object sender, EventArgs e)
        {
            List<StockOut> stockOuts = new List<StockOut>();
            if (ViewState["Stock Out"] != null)
            {
                stockOuts = (List<StockOut>)ViewState["Stock Out"];
            }

            int companyId = Convert.ToInt32(ddlCompany.SelectedValue);
            string compnayName = ddlCompany.SelectedItem.Text;
            int itemId = Convert.ToInt32(ddlItem.SelectedValue);
            string itemName = ddlItem.SelectedItem.Text;
            int quantity = Convert.ToInt32(stockOutTextBox.Text);

            stockOuts.Add(new StockOut() { CompanyId = companyId,CompanyName = compnayName,ItemId = itemId,ItemName = itemName,StockOutQuantity = quantity });
            showAllGridView.DataSource = stockOuts;
            showAllGridView.DataBind();
            ViewState["Stock Out"] = stockOuts;
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
            aItem = items.GetAItem(Convert.ToInt32(ddlItem.SelectedValue));
            quantityLabel.Text = aItem.Quantity.ToString();
            reorderLabel.Text = aItem.ReorderLabel.ToString();
        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            List<StockOut> stockOuts = (List<StockOut>)ViewState["Stock Out"];
            foreach (var items in stockOuts)
            {
                int companyId = items.CompanyId;
                int itemId = items.ItemId;
                int quantity = items.StockOutQuantity;
                string time = DateTime.Today.ToString("yyyy MMMM dd");
                stockOut.SaveSaleQuantity(companyId, itemId, quantity,time);
                stockOut.SaveStockOut(companyId, itemId, quantity);
            }
        }


    }
}
