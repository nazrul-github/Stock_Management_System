using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock_Management_System.BLL;

namespace Stock_Management_System.MODELS
{
    public class Category
    {
        CategoryManager _categoryManager = new CategoryManager();

        public string CategoryName { get; private set; }
        public string CategoryID { get; private set; }

        public string SaveCategory(string aCategory)
        {
            this.CategoryName = aCategory;
            return SendCategory(this.CategoryName);
        }

        private string SendCategory(string aCategory)
        {
            return _categoryManager.SendCategory(aCategory);
        }

        internal void GetValidCategory(string categoryName,string categoryId)
        {
            if (_categoryManager.IsCategoryExist(categoryName))
            {
                this.CategoryName = categoryName;
                this.CategoryID = categoryId;
            }
        }
        public List<Category> GetCategories()
        {
            return _categoryManager.GetCategories();
        }
    }
}