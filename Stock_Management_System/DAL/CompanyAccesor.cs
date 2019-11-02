using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Stock_Management_System.MODELS;

namespace Stock_Management_System.DAL
{
    public class CompanyAccesor
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public bool IsExist(string aCompany)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM tbl_company WHERE CompanyName = @CompanyName";
                cmd.Parameters.AddWithValue("@CompanyName", aCompany);
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

        public bool SendCompany(string aCompany)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO tbl_company VALUES(@CompanyName);";
                cmd.Parameters.AddWithValue("@CompanyName", aCompany);
                cmd.Connection = connection;
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

        public List<Company> ShowCompanies()
        {
            List<Company> allCompanies = new List<Company>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM tbl_company";
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Company aCompany = new Company();
                    aCompany.GetValidCompany(reader["CompanyName"].ToString());
                    allCompanies.Add(aCompany);
                }

                reader.Close();
                connection.Close();
                return allCompanies;
            }
        }
    }
}