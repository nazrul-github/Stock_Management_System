using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock_Management_System.DAL;
using Stock_Management_System.MODELS;

namespace Stock_Management_System.BLL
{
    public class ItemsManager
    {
        ItemsAccesor itemsAccesor = new ItemsAccesor();
        internal bool IsExist(string itemName)
        {
            return itemsAccesor.IsExist(itemName);
        }
        public string SendItems(int categoryId, int companyId, string itemName, int reorderLabel)
        {
            if (IsExist(itemName))
            {
                return "Item name alraeady exist";
            }

            bool isSaved = itemsAccesor.GetSaved(categoryId, companyId, itemName, reorderLabel);
            if (isSaved)
            {
                return "Item saved successfully";
            }

            return "Item saving failed";
        }

        public List<Items> GetItem(int companyId)
        {
            return itemsAccesor.GetItem(companyId);
        }
    }
}