using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock_Management_System.BLL;

namespace Stock_Management_System.MODELS
{
    public class Company
    {
        CompanyManager companyManager = new CompanyManager();
        public string CompanyName { get; private set; }
        public string CompanyID { get; set; }

        public string SaveCompany(string companyName)
        {
            this.CompanyName = companyName;
            return SendCompany(this.CompanyName);
        }

        private string SendCompany(string aCompany)
        {
            return companyManager.SendCompany(aCompany);
        }

        internal void GetValidCompany(string companyName,string companyId)
        {
            if (companyManager.isCompanyExist(companyName))
            {
                this.CompanyName = companyName;
                this.CompanyID = companyId;
            }
        }
        internal List<Company> ShowCompanies()
        {
            return companyManager.ShowCompanies();
        }
    }
}