using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock_Management_System.BLL;

namespace Stock_Management_System.MODELS
{
    public class StockIn
    {
        StockManager stockManager = new StockManager();
        public int ItemId { get; set; }
        public int CompanyId { get; set; }
        public int StockInQuatity { get; set; }

        public string SaveStockIn(int companyId, int itemId, int stockInQuantity)
        {
            this.CompanyId = companyId;
            this.ItemId = itemId;
            this.StockInQuatity = stockInQuantity;
            return SendStockInQuantity(this.CompanyId, this.ItemId,  this.StockInQuatity);
        }

        private string SendStockInQuantity(int companyId, int itemId, int quantity)
        {
            return stockManager.SendStockInQuantity(companyId, itemId, quantity);
        }
    }
}