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
    public class ItemsAccesor
    {
        private readonly string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public bool IsExist(string itemName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM tbl_Items WHERE ItemName = @ItemName";
                cmd.Parameters.AddWithValue("@ItemName", itemName);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    connection.Close();
                    return true;
                }
                reader.Close();
                connection.Close();
                return false;
            }
        }

        public bool GetSaved(int categoryId, int companyId, string itemName, int reorderLabel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "sp_InsertITems";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemName", itemName);
                cmd.Parameters.AddWithValue("@ReorderLabel", reorderLabel);
                cmd.Parameters.AddWithValue("@CompanyId", companyId);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
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

        public List<Items> GetItem(int companyId)
        {
            List<Items> allItems = new List<Items>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT *  FROM tbl_ItemsAvailableQuantity WHERE CompanyId = @CompanyId ORDER BY ItemName DESC; ";
                cmd.Parameters.AddWithValue("@CompanyId", companyId);
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Items aItem = new Items();
                    aItem.GetValidItems(reader["ItemName"].ToString(), Convert.ToInt32(reader["ItemID"]),
                        Convert.ToInt32(reader["ReorderLabel"]), Convert.ToInt32(reader["Quantity"]));
                    allItems.Add(aItem);
                }
                reader.Read();
                connection.Close();
                return allItems;
            }
        }


        public Items GetAItem(int itemId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT *  FROM tbl_ItemsAvailableQuantity WHERE ItemID = @ItemId ; ";
                cmd.Parameters.AddWithValue("@ItemId", itemId);
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                    Items aItem = new Items();
                while (reader.Read())
                {
                    aItem.GetValidItems(reader["ItemName"].ToString(), Convert.ToInt32(reader["ItemID"]),
                        Convert.ToInt32(reader["ReorderLabel"]), Convert.ToInt32(reader["Quantity"]));
                }
                reader.Read();
                connection.Close();
                return aItem;
            }
        }
    }
}