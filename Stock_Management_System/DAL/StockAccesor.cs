using System;
using System.Collections.Generic;
using System.Data;
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
        public bool SendStockOutQuantity(int companyId, int itemId, int stockOutQuantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "UPDATE tbl_Items SET StockOut = @Quantity WHERE CompanyId = @CompanyId AND ItemID = @ItemId;";
                cmd.Parameters.AddWithValue("@Quantity", stockOutQuantity);
                cmd.Parameters.AddWithValue("@CompanyId", companyId);
                cmd.Parameters.AddWithValue("@ItemId", itemId);
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

        public bool SendSellQuantity(int companyId, int itemId, int stockOutQuantity, string stockOutTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "INSERT INTO tbl_Sales VALUES(@CompanyId,@ItemId,@Quantity,@Time);";
                cmd.Parameters.AddWithValue("@Quantity", stockOutQuantity);
                cmd.Parameters.AddWithValue("@CompanyId", companyId);
                cmd.Parameters.AddWithValue("@ItemId", itemId);
                SqlParameter dateParameter = new SqlParameter();
                dateParameter.ParameterName = "@Time";
                dateParameter.DbType = DbType.Date;
                dateParameter.Value = stockOutTime;
                cmd.Parameters.Add(dateParameter);
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

        public bool SendDamageQuantity(int companyId, int itemId, int stockOutQuantity, string stockOutTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "INSERT INSERT INTO tbl_Damaged VALUES(@CompanyId,@ItemId,@Quantity,@Time);";
                cmd.Parameters.AddWithValue("@Quantity", stockOutQuantity);
                cmd.Parameters.AddWithValue("@CompanyId", companyId);
                cmd.Parameters.AddWithValue("@ItemId", itemId);
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

        public bool SendLostQuantity(int companyId, int itemId, int stockOutQuantity, string stockOutTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    "INSERT INSERT INTO tbl_Lost VALUES(@CompanyId,@ItemId,@Quantity,@Time);";
                cmd.Parameters.AddWithValue("@Quantity", stockOutQuantity);
                cmd.Parameters.AddWithValue("@CompanyId", companyId);
                cmd.Parameters.AddWithValue("@ItemId", itemId);
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

        public List<StockOut> soldItems(string startDate, string endDate)
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