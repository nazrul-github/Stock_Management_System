using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Stock_Management_System.MODELS;

namespace Stock_Management_System.DAL
{
    [Serializable]
    public class StockAccesor
    {
        private readonly string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public bool SendStockInQuantity(int companyId, int itemId, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "UPDATE tbl_Items SET StockIn = @Quantity WHERE CompanyId = @CompanyId AND ItemID = @ItemID;";
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@CompanyId", companyId);
                cmd.Parameters.AddWithValue("@ItemID", itemId);
                connection.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;
            }
        }
        public bool SendStockOutQuantity(string companyName, string itemName, int stockOutQuantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "UPDATE tbl_Items SET StockOut = @Quantity WHERE CompanyName = @CompanyName AND ItemName = @ItemName;";
                cmd.Parameters.AddWithValue("@Quantity", stockOutQuantity);
                cmd.Parameters.AddWithValue("@CompanyName", companyName);
                cmd.Parameters.AddWithValue("@ItemName", itemName);
                connection.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;
            }
        }

        public bool SendSellQuantity(string companyName, string itemName, int stockOutQuanity, DateTime stockOutTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "INSERT INSERT INTO tbl_Sales VALUES(@CompanyName,@ItemName,@Quantity,@Time);";
                cmd.Parameters.AddWithValue("@Quantity", stockOutQuanity);
                cmd.Parameters.AddWithValue("@CompanyName", companyName);
                cmd.Parameters.AddWithValue("@ItemName", itemName);
                cmd.Parameters.AddWithValue("@Time", stockOutTime);
                connection.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;
            }
        }

        public bool SendDamageQuantity(string companyName, string itemName, int stockOutQuanity, DateTime stockOutTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "INSERT INSERT INTO tbl_Damaged VALUES(@CompanyId,@ItemId,@Quantity,@Time);";
                cmd.Parameters.AddWithValue("@Quantity", stockOutQuanity);
                cmd.Parameters.AddWithValue("@CompanyId", companyName);
                cmd.Parameters.AddWithValue("@ItemID", itemName);
                cmd.Parameters.AddWithValue("@StockOutTime", stockOutTime);
                connection.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;
            }
        }

        public bool SendLostQuantity(string companyName, string itemName, int stockOutQuanity, DateTime stockOutTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "INSERT INSERT INTO tbl_Lost VALUES(@CompanyId,@ItemId,@Quantity,@Time);";
                cmd.Parameters.AddWithValue("@Quantity", stockOutQuanity);
                cmd.Parameters.AddWithValue("@CompanyId", companyName);
                cmd.Parameters.AddWithValue("@ItemID", itemName);
                cmd.Parameters.AddWithValue("@StockOutTime", stockOutTime);
                connection.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;
            }
        }

        public List<StockOut> soldItems(DateTime startDate, DateTime endDate)
        {
            List<StockOut> allSales = new List<StockOut>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " SELECT * FROM tbl_SalesSheet WHERE StockOutTime BETWEEN @StartTime AND @EndTime;";
                cmd.Parameters.AddWithValue("@StartTime", startDate);
                cmd.Parameters.AddWithValue("@EndTime", endDate);
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockOut aSale = new StockOut();
                    aSale.GetSales(reader["ItemName"].ToString(), Convert.ToInt32(reader["Quantity"]));
                    allSales.Add(aSale);
                }
                reader.Read();
                connection.Close();
                return allSales;
            }
        }
    }
}