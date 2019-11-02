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
        private int _itemID;
        private int _company_id;
        private int _stockInQuanity;

        public string SaveStockIn(int companyId, int itemId, int stockInQuantity)
        {
            this._company_id = companyId;
            this._itemID = itemId;
            this._stockInQuanity = stockInQuantity;
            return SendStockInQuantity(this._company_id, this._itemID,  this._stockInQuanity);
        }

        private string SendStockInQuantity(int companyId, int itemId, int quantity)
        {
            return stockManager.SendStockInQuantity(companyId, itemId, quantity);
        }
    }
}