using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stock_Management_System.MODELS;

namespace Stock_Management_System
{
    public partial class ViewSalesBetweenDates : System.Web.UI.Page
    {
        StockOut stockOut = new StockOut();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromdateTextBox.Text;
            string toDate = todateTextbox.Text;
            showAllGridView.DataSource = stockOut.GetsoldItems(fromDate, toDate);
            showAllGridView.DataBind();
        }
    }
}