using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock_Management_System.BLL;

namespace Stock_Management_System.MODELS
{
    public class Category
    {
        CategoryManager categoryManager = new CategoryManager();
        private string _category;

        public string SaveCategory(string aCategory)
        {
            this._category = aCategory;
            return SendCategory(aCategory);
        }

        private string SendCategory(string aCategory)
        {
            return categoryManager.SendCategory(aCategory);
        }

        internal void GetValidCategory(string aCategory)
        {
            if (categoryManager.IsCategoryExist(aCategory))
            {
                this._category = aCategory;
            }
        }
        public List<Category> GetCategories()
        {
            return categoryManager.GetCategories();
        }
    }
}