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

        public string SendStockOutQuantity(int companyId, int itemId, int stockOutQuantity)
        {
            bool isSaved = stockAccesor.SendStockOutQuantity(companyId, itemId, stockOutQuantity);
            if (isSaved)
            {
                return "Quantity updated successfully";
            }

            return "Quantity update failed";
        }

        public string SendSellQuantity(int companyId, int itemId, int stockOutQuantity, string stockOutTime)
        {
            bool isSaved = stockAccesor.SendSellQuantity(companyId, itemId, stockOutQuantity, stockOutTime);
            if (isSaved)
            {
                return "Quantity updated successfully";
            }

            return "Quantity update failed";
        }

        public string SendDamageQuantity(int companyId, int itemId, int stockOutQuantity, string stockOutTime)
        {
            bool isSaved = stockAccesor.SendDamageQuantity(companyId, itemId, stockOutQuantity, stockOutTime);
            if (isSaved)
            {
                return "Quantity updated successfully";
            }

            return "Quantity update failed";
        }

        public string SendLostQuantity(int companyId, int itemId, int stockOutQuantity, string stockOutTime)
        {
            bool isSaved = stockAccesor.SendLostQuantity(companyId, itemId, stockOutQuantity, stockOutTime);
            if (isSaved)
            {
                return "Quantity updated successfully";
            }

            return "Quantity update failed";
        }

        public List<StockOut> soldItems(string startDate, string endDate)
        {
            return stockAccesor.soldItems(startDate,endDate);
        }
    }
}