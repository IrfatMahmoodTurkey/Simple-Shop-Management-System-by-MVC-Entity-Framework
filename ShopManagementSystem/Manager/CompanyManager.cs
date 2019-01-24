using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopManagementSystem.Gateway;
using ShopManagementSystem.Models;

namespace ShopManagementSystem.Manager
{
    public class CompanyManager
    {
        private CompanyGateway companyGateway;

        public CompanyManager()
        {
            companyGateway = new CompanyGateway();
        }

        public int Add(Company company)
        {
            if (companyGateway.IsCompanyExists(company))
            {
                return 2;
            }
            else
            {
                int rowsAffected = companyGateway.Add(company);

                if (rowsAffected > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool IsCompanyExistsById(int id)
        {
            return companyGateway.IsCompanyExistsById(id);
        }


        public List<Company> GetAllCompanies()
        {
            return companyGateway.GetAllCompanies();
        }

        public Company GetCompanyById(int id)
        {
            return companyGateway.GetCompanyById(id);
        }

        public int UpdateCompany(Company company)
        {
            if (companyGateway.IsCompanyExists(company))
            {
                return 2;
            }
            else
            {
                int rowsAffected = companyGateway.UpdateCompany(company);

                if (rowsAffected > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public List<SelectListItem> GetCompaniesForDropDown()
        {
            List<Company> companies = GetAllCompanies();

            List<SelectListItem> listItems =
                companies.ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });

            List<SelectListItem> mainListItems = new List<SelectListItem>();
            mainListItems.Add(new SelectListItem()
            {
                Text = "--Select Company--",
                Value = ""
            });

            mainListItems.AddRange(listItems);

            return mainListItems;
        } 
    }
}