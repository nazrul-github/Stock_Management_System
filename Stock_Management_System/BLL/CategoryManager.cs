using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock_Management_System.DAL;
using Stock_Management_System.MODELS;

namespace Stock_Management_System.BLL
{
    public class CategoryManager
    {
        CategoryAccessor categoryAccessor = new CategoryAccessor();

        internal bool IsCategoryExist(string aCategory)
        {
            return categoryAccessor.IsCategoryExist(aCategory);
        }
        internal string SendCategory(string aCategory)
        {
            if (IsCategoryExist(aCategory))
            {
                return "Category already exist";
            }

            bool isSaved = categoryAccessor.SendCategory(aCategory);
            if (isSaved)
            {
                return "Category saved successfully";
            }

            return "Category saving failed";
        }

        public List<Category> GetCategories()
        {
            return categoryAccessor.GetCategories();
        }
    }
}