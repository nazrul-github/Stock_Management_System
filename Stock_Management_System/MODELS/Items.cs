using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock_Management_System.BLL;

namespace Stock_Management_System.MODELS
{
    public class Items
    {
        ItemsManager itemsManager = new ItemsManager();
        private string _itemName;
        private int _category_id;
        private int _reorderLabel;
        private int _itemID;
        private int _company_id;
        private int _quanity;

        public List<Items> GetItem(int companyId)
        {
            return itemsManager.GetItem(companyId);
        }

        public string SaveItems(int categoryId, int companyId, string itemName, int reorderLabel)
        {
            this._category_id = categoryId;
            this._company_id = companyId;
            this._itemName = itemName;
            this._reorderLabel = reorderLabel;

            return SendItems(this._category_id, this._company_id, this._itemName, this._reorderLabel);
        }

        private string SendItems(int categoryId, int companyId, string itemName, int reorderLabel)
        {
            return itemsManager.SendItems(categoryId, companyId, itemName, reorderLabel);
        }

        internal void GetValidItems(string itemName, int itemId, int reorderLabel, int quantity)
        {
            if (itemsManager.IsExist(itemName))
            {
                this._itemName = itemName;
                this._itemID = itemId;
                this._reorderLabel = reorderLabel;
                this._quanity = quantity;
            }
        }
    }
}