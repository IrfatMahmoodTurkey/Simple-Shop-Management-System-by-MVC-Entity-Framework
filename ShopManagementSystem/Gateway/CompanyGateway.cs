using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ShopManagementSystem.Models;

namespace ShopManagementSystem.Gateway
{
    public class CompanyGateway:CommonContext
    {
        public int Add(Company company)
        {
            Context.Companies.Add(company);
            int rowsAffected = Context.SaveChanges();

            return rowsAffected;
        }

        public bool IsCompanyExistsById(int id)
        {
            bool isExists = Context.Companies.Any(c => c.Id == id);
            return isExists;
        }

        public bool IsCompanyExists(Company company)
        {
            bool isExists = Context.Companies.Any(c => c.Name == company.Name);
            return isExists;
        }

        public List<Company> GetAllCompanies()
        {
            return Context.Companies.OrderByDescending(c => c.Id).ToList();
        }

        public Company GetCompanyById(int id)
        {
            return Context.Companies.Where(c => c.Id == id).FirstOrDefault();
        }

        public int UpdateCompany(Company company)
        {
            Context.Companies.AddOrUpdate(company);
            int rowsAffected = Context.SaveChanges();

            return rowsAffected;
        }
    }
}