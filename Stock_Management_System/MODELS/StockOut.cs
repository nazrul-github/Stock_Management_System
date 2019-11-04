using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock_Management_System.BLL;

namespace Stock_Management_System.MODELS
{
    [Serializable]
    public class StockOut
    {
        StockManager stockManager = new StockManager();
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int StockOutQuantity { get; set; }
        public string StockOutTime { get; set; }

        public string SaveStockOut(int companyId, int itemId, int stockOutQuantity)
        {
            this.CompanyId = companyId;
            this.ItemId = itemId;
            this.StockOutQuantity = stockOutQuantity;
            return SendStockOutQuantity(this.CompanyId,this.ItemId,this.StockOutQuantity);
        }

        private string SendStockOutQuantity(int companyId, int itemId, int stockOutQuantity)
        {
            return stockManager.SendStockOutQuantity(companyId, itemId, stockOutQuantity);
        }
        public string SaveSaleQuantity(int companyId, int itemId, int stockOutQuantity, string stockOutTime)
        {
            this.CompanyId = companyId;
            this.ItemId = itemId;
            this.StockOutQuantity = stockOutQuantity;
            this.StockOutTime = stockOutTime;
            return SendSellQuantity(this.CompanyId, this.ItemId, this.StockOutQuantity,this.StockOutTime);
        }

        private string SendSellQuantity(int companyId, int itemId, int stockOutQuantity,string stockOutTime)
        {
            return stockManager.SendSellQuantity(companyId, itemId, stockOutQuantity, stockOutTime);
        }
        public string SaveDamageQuantity(int companyId, int itemId, int stockOutQuantity, string stockOutTime)
        {
            this.CompanyId = companyId;
            this.ItemId = itemId;
            this.StockOutQuantity = stockOutQuantity;
            this.StockOutTime = StockOutTime;
            return SendDamageQuantity(this.CompanyId, this.ItemId, this.StockOutQuantity, this.StockOutTime);
        }

        private string SendDamageQuantity(int companyId, int itemId, int stockOutQuantity, string stockOutTime)
        {
            return stockManager.SendDamageQuantity(this.CompanyId, this.ItemId, this.StockOutQuantity, this.StockOutTime);
        }
        public string SaveLostQuantity(int companyId, int itemId, int lostQuantity, string timeStamp)
        {
            this.CompanyId = companyId;
            this.ItemId = itemId;
            this.StockOutQuantity = lostQuantity;
            this.StockOutTime = StockOutTime;
            return SendLostQuantity(this.CompanyId, this.ItemId, this.StockOutQuantity, this.StockOutTime);
        }

        private string SendLostQuantity(int companyId, int itemId, int damageQuantity, string timeStamp)
        {
            return stockManager.SendLostQuantity(this.CompanyId, this.ItemId, this.StockOutQuantity, this.StockOutTime);
        }

        internal void GetSales(string itemName, int salesQuantity)
        {
            this.ItemName = itemName;
            this.StockOutQuantity = salesQuantity;

        }

        public List<StockOut> GetsoldItems(string startDate, string endDate)
        {
            return stockManager.soldItems(startDate,endDate);
        }

    }
}