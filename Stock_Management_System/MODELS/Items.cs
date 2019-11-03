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
        public string ItemName { get; private set; }
        public int CategoryId { get; private set; }
        public int ReorderLabel { get; private set; }
        public int ItemId { get; private set; }
        public int CompanyId { get; private set; }
        public int Quantity { get; private set; }

        public List<Items> GetItem(int companyId)
        {
            return itemsManager.GetItem(companyId);
        }

        public Items GetAItem(int itemId)
        {
            return itemsManager.GetAItem(itemId);
        }

        public string SaveItems(int categoryId, int companyId, string itemName, int reorderLabel)
        {
            this.CategoryId = categoryId;
            this.CompanyId = companyId;
            this.ItemName = itemName;
            this.ReorderLabel = reorderLabel;

            return SendItems(this.CategoryId, this.CompanyId, this.ItemName, this.ReorderLabel);
        }

        private string SendItems(int categoryId, int companyId, string itemName, int reorderLabel)
        {
            return itemsManager.SendItems(categoryId, companyId, itemName, reorderLabel);
        }

        internal void GetValidItems(string itemName, int itemId, int reorderLabel, int quantity)
        {
            if (itemsManager.IsExist(itemName))
            {
                this.ItemName = itemName;
                this.ItemId = itemId;
                this.ReorderLabel = reorderLabel;
                this.Quantity = quantity;
            }
        }
    }
}