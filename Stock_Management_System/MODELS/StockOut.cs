using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock_Management_System.BLL;

namespace Stock_Management_System.MODELS
{
    public class StockOut
    {
        StockManager stockManager = new StockManager();
        private int _itemID;
        private string _itemName;
        private int _company_id;
        private int _stockOutQuanity;
        public DateTime _stockOutTime { get; set; }

        public string SaveStockOut(int companyId, int itemId, int stockOutQuantity)
        {
            this._company_id = companyId;
            this._itemID = itemId;
            this._stockOutQuanity = stockOutQuantity;
            return SendStockOutQuantity(this._company_id,this._itemID,this._stockOutQuanity);
        }

        private string SendStockOutQuantity(int companyId, int itemId, int stockOutQuantity)
        {
            return stockManager.SendStockOutQuantity(companyId, itemId, stockOutQuantity);
        }
        public string SaveSaleQuantity(int companyId, int itemId, int sellQuantity,DateTime timeStamp)
        {
            this._company_id = companyId;
            this._itemID = itemId;
            this._stockOutQuanity = sellQuantity;
            this._stockOutTime = timeStamp;
            return SendSellQuantity(this._company_id,this._itemID,this._stockOutQuanity,this._stockOutTime);
        }

        private string SendSellQuantity(int companyId, int itemId, int stockOutQuantity, DateTime timeStamp)
        {
            return stockManager.SendSellQuantity(this._company_id, this._itemID, this._stockOutQuanity, this._stockOutTime);
        }
        public string SaveDamageQuantity(int companyId, int itemId, int damageQuantity, DateTime timeStamp)
        {
            this._company_id = companyId;
            this._itemID = itemId;
            this._stockOutQuanity = damageQuantity;
            return SendDamageQuantity(this._company_id, this._itemID, this._stockOutQuanity, this._stockOutTime);
        }

        private string SendDamageQuantity(int companyId, int itemId, int damageQuantity, DateTime timeStamp)
        {
            return stockManager.SendDamageQuantity(this._company_id, this._itemID, this._stockOutQuanity, this._stockOutTime);
        }
        public string SaveLostQuantity(int companyId, int itemId, int lostQuantity, DateTime timeStamp)
        {
            this._company_id = companyId;
            this._itemID = itemId;
            this._stockOutQuanity = lostQuantity;
            return SendLostQuantity(this._company_id, this._itemID, this._stockOutQuanity, this._stockOutTime);
        }

        private string SendLostQuantity(int companyId, int itemId, int damageQuantity, DateTime timeStamp)
        {
            return stockManager.SendLostQuantity(this._company_id, this._itemID, this._stockOutQuanity, this._stockOutTime);
        }

        internal void GetSales(string itemName, int salesQuantity)
        {
            this._itemName = itemName;
            this._stockOutQuanity = salesQuantity;

        }

        public List<StockOut> soldItems(DateTime startDate, DateTime endDate)
        {
            return stockManager.soldItems(startDate,endDate);
        }

    }
}