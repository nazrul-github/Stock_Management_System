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
        private string _companyName;

        public string SaveCompany(string companyName)
        {
            this._companyName = companyName;
            return SendCompany(this._companyName);
        }

        private string SendCompany(string aCompany)
        {
            return companyManager.SendCompany(aCompany);
        }

        internal void GetValidCompany(string aCompany)
        {
            if (companyManager.isCompanyExist(aCompany))
            {
                this._companyName = aCompany;
            }
        }
        internal List<Company> ShowCompanies()
        {
            return companyManager.ShowCompanies();
        }
    }
}