using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock_Management_System.DAL;
using Stock_Management_System.MODELS;

namespace Stock_Management_System.BLL
{
    public class CompanyManager
    {
        CompanyAccesor companyAccesor = new CompanyAccesor();

        internal bool isCompanyExist(string aCompany)
        {
            return companyAccesor.IsExist(aCompany);
        }

        public string SendCompany(string aCompany)
        {
           
            if (isCompanyExist(aCompany))
            {
                return "Company name already exist.";
            }

            bool isSaved = companyAccesor.SendCompany(aCompany);

            if (isSaved)
            {
                return "Company saved successfully";
            }

            return "Company saving failed.";
        }

        public List<Company> ShowCompanies()
        {
           return companyAccesor.ShowCompanies();
        }

       
    }
}