using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Stock_Management_System.MODELS;

namespace Stock_Management_System.DAL
{
    public class CategoryAccessor
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        internal bool IsCategoryExist(string aCategory)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM tbl_Category WHERE Category = @Category;";
                cmd.Parameters.AddWithValue("@Category", aCategory);
                cmd.Connection = connection;
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

        internal bool SendCategory(string aCategory)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO tbl_Category VALUES(@Category);";
                cmd.Parameters.AddWithValue("@Category", aCategory);
                cmd.Connection = connection;
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

        public List<Category> GetCategories()
        {
            List<Category> allCategories = new List<Category>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM tbl_Category;";
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category aCategory = new Category();
                    aCategory.GetValidCategory(reader["CategoryName"].ToString());
                    allCategories.Add(aCategory);
                }
                connection.Close();
                return allCategories;
            }
        }
    }
}