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
    public partial class CompanySetup : System.Web.UI.Page
    {
        Company aCompany = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetGridBoxFilled();
        }


        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string companyName = companyNameTextBox.Text;
                msgLabel.Text = aCompany.SaveCompany(companyName);
                msgLabel.ForeColor = Color.Green;
                companyNameTextBox.Text = string.Empty;
                GetGridBoxFilled();
            }
            else
            {
                msgLabel.Text = "Please check the text box";
                msgLabel.ForeColor = Color.Red;
            }
        }
        private void GetGridBoxFilled()
        {
            showAllGridView.DataSource = aCompany.ShowCompanies();
            showAllGridView.DataBind();
        }
    }
}