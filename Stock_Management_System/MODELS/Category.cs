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
        private string _category;

        public string SaveCategory(string aCategory)
        {
            this._category = aCategory;
            return SendCategory(this._category);
        }

        private string SendCategory(string aCategory)
        {
            return _categoryManager.SendCategory(aCategory);
        }

        internal void GetValidCategory(string aCategory)
        {
            if (_categoryManager.IsCategoryExist(aCategory))
            {
                this._category = aCategory;
            }
        }
        public List<Category> GetCategories()
        {
            return _categoryManager.GetCategories();
        }
    }
}