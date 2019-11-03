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
    public partial class WebForm2 : System.Web.UI.Page
    {
        Items items = new Items();
        Category category = new Category();
        Company company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryNameDropDownList.DataTextField = "CategoryName";
                categoryNameDropDownList.DataValueField = "CategoryID";
                categoryNameDropDownList.DataSource = category.GetCategories();
                categoryNameDropDownList.DataBind();

                companyNameDropDownList.DataTextField = "CompanyName";
                companyNameDropDownList.DataValueField = "CompanyID";
                companyNameDropDownList.DataSource = company.ShowCompanies();
                companyNameDropDownList.DataBind();
                companyNameDropDownList.Items.Insert(0,new ListItem("--Please Select Company--","0"));
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int categoryId = Convert.ToInt32(categoryNameDropDownList.SelectedValue);
                int companyId = Convert.ToInt32(companyNameDropDownList.SelectedValue);
                string itemName = itemNameTextBox.Text;
                int reorderLabel = Convert.ToInt32(reorderLabelTextBox.Text);
                msgLabel.Text = items.SaveItems(categoryId, companyId, itemName, reorderLabel);
                msgLabel.ForeColor = Color.Green;

                companyNameDropDownList.SelectedValue = "0";
                categoryNameDropDownList.SelectedValue = "0";
                reorderLabelTextBox.Text = String.Empty;
                itemNameTextBox.Text = String.Empty;
            }
            else
            {
                msgLabel.Text = "Validation failed!!! Please check all the inputs";
                msgLabel.ForeColor = Color.Red;
            }
        }
    }
}