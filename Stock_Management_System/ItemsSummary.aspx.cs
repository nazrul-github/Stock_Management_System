using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stock_Management_System.MODELS;

namespace Stock_Management_System
{
    public partial class ItemsSummary : System.Web.UI.Page
    {
        Company aCompany = new Company();
        Category aCategory = new Category();
        Items items = new Items();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCompany.DataTextField = "CompanyName";
                ddlCompany.DataValueField = "CompanyID";
                ddlCompany.DataSource = aCompany.ShowCompanies();
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0,new ListItem("--Select Company--","0"));

                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataSource = aCategory.GetCategories();
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));

            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            int companyId = Convert.ToInt32(ddlCompany.SelectedValue);
            int categoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            if (ddlCompany.SelectedIndex != 0 && ddlCategory.SelectedIndex != 0)
            {
                showAllGridView.DataSource = items.GetCompanyAndCategory(companyId, categoryId);
                showAllGridView.DataBind();

            }
            else
            {
                showAllGridView.DataSource = items.GetCompanyOrCategory(companyId, categoryId);
                showAllGridView.DataBind();
            }
        }
    }
}