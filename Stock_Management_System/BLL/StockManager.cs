using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock_Management_System.DAL;
using Stock_Management_System.MODELS;

namespace Stock_Management_System.BLL
{
    [Serializable]
    public class StockManager
    {
        StockAccesor stockAccesor = new StockAccesor();
        
        internal string SendStockInQuantity(int companyId, int itemId, int quantity)
        {
            bool isSaved = stockAccesor.SendStockInQuantity(companyId, itemId, quantity);
            if (isSaved)
            {
                return "Quantity updated successfully";
            }

            return "Updating quantity failed";
        }

        public string SendStockOutQuantity(string companyName, string itemName, int stockOutQuantity)
        {
            bool isSaved = stockAccesor.SendStockOutQuantity(companyName, itemName, stockOutQuantity);
            if (isSaved)
            {
                return "Quantity updated successfully";
            }

            return "Quantity update failed";
        }

        public string SendSellQuantity(string companyName, string itemName, int stockOutQuanity, DateTime stockOutTime)
        {
            bool isSaved = stockAccesor.SendSellQuantity(companyName, itemName, stockOutQuanity,stockOutTime);
            if (isSaved)
            {
                return "Quantity updated successfully";
            }

            return "Quantity update failed";
        }

        public string SendDamageQuantity(string companyName, string itemName, int stockOutQuanity, DateTime stockOutTime)
        {
            bool isSaved = stockAccesor.SendDamageQuantity(companyName, itemName, stockOutQuanity, stockOutTime);
            if (isSaved)
            {
                return "Quantity updated successfully";
            }

            return "Quantity update failed";
        }

        public string SendLostQuantity(string companyName, string itemName, int stockOutQuanity, DateTime stockOutTime)
        {
            bool isSaved = stockAccesor.SendLostQuantity(companyName, itemName, stockOutQuanity, stockOutTime);
            if (isSaved)
            {
                return "Quantity updated successfully";
            }

            return "Quantity update failed";
        }

        public List<StockOut> soldItems(DateTime startDate, DateTime endDate)
        {
            return stockAccesor.soldItems(startDate,endDate);
        }
    }
}