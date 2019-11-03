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
    public partial class WebForm1 : System.Web.UI.Page
    {
        Category aCategory = new Category();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetGridViewFilled();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string categoryName = categoryNameTextBox.Text;
                msgLabel.Text = aCategory.SaveCategory(categoryName);
                msgLabel.ForeColor = Color.Green;
                categoryNameTextBox.Text = string.Empty;
                GetGridViewFilled();
            }
            else
            {
                msgLabel.Text = "Category saving failed check the text box";
                msgLabel.ForeColor = Color.Red;
            }
        }

        private void GetGridViewFilled()
        {
            showAllGridView.DataSource = aCategory.GetCategories();
            showAllGridView.DataBind();
        }



    }
}