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
        public DateTime StockOutTime { get; set; }

        public string SaveStockOut(string companyName, string itemName, int stockOutQuantity)
        {
            this.CompanyName = companyName;
            this.ItemName = itemName;
            this.StockOutQuantity = stockOutQuantity;
            return SendStockOutQuantity(this.CompanyName,this.ItemName,this.StockOutQuantity);
        }

        private string SendStockOutQuantity(string companyName, string itemName, int stockOutQuantity)
        {
            return stockManager.SendStockOutQuantity(companyName, itemName, stockOutQuantity);
        }
        public string SaveSaleQuantity(string companyName, string itemName, int stockOutQuantity)
        {
            this.CompanyName = companyName;
            this.ItemName = itemName;
            this.StockOutQuantity = stockOutQuantity;
            return SendStockOutQuantity(this.CompanyName, this.ItemName, this.StockOutQuantity);
        }

        private string SendSellQuantity(string companyName, string itemName, int stockOutQuantity)
        {
            return stockManager.SendSellQuantity(companyName, itemName, stockOutQuantity, this.StockOutTime);
        }
        public string SaveDamageQuantity(string companyName, string itemName, int damageQuantity, DateTime timeStamp)
        {
            this.CompanyName = companyName;
            this.ItemName = itemName;
            this.StockOutQuantity = damageQuantity;
            return SendDamageQuantity(this.CompanyName, this.ItemName, this.StockOutQuantity, this.StockOutTime);
        }

        private string SendDamageQuantity(string companyName, string itemName, int damageQuantity, DateTime timeStamp)
        {
            return stockManager.SendDamageQuantity(this.CompanyName, this.ItemName, this.StockOutQuantity, this.StockOutTime);
        }
        public string SaveLostQuantity(int companyId, int itemId, int lostQuantity, DateTime timeStamp)
        {
            this.CompanyId = companyId;
            this.ItemId = itemId;
            this.StockOutQuantity = lostQuantity;
            return SendLostQuantity(this.CompanyId, this.ItemId, this.StockOutQuantity, this.StockOutTime);
        }

        private string SendLostQuantity(int companyId, int itemId, int damageQuantity, DateTime timeStamp)
        {
            return stockManager.SendLostQuantity(this.CompanyName, this.ItemName, this.StockOutQuantity, this.StockOutTime);
        }

        internal void GetSales(string itemName, int salesQuantity)
        {
            this.ItemName = itemName;
            this.StockOutQuantity = salesQuantity;

        }

        public List<StockOut> soldItems(DateTime startDate, DateTime endDate)
        {
            return stockManager.soldItems(startDate,endDate);
        }

    }
}