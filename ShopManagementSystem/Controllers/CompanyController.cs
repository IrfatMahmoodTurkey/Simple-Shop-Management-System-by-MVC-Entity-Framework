using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopManagementSystem.Manager;
using ShopManagementSystem.Models;
using ShopManagementSystem.Utility;

namespace ShopManagementSystem.Controllers
{
    public class CompanyController : Controller
    {
        private CompanyManager companyManager;

        public CompanyController()
        {
            companyManager = new CompanyManager();
        }
        //
        // GET: /Company/
        [HttpGet]
        public ActionResult SaveCompany()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return HttpNotFound();
            }    
        }

        [HttpPost]
        public ActionResult SaveCompany(Company company)
        {
            if (Request.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    company.ActionDate = DateTime.Now.ToString();
                    company.ActionType = ActionType.Insert;
                    company.ActionBy = ActionType.User;

                    ViewBag.Response = companyManager.Add(company);
                }
                else
                {
                    ViewBag.Response = 3;
                }

                ModelState.Clear();
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult ViewAllCompanies()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.Companies = companyManager.GetAllCompanies();
                return View();
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Request.IsAuthenticated)
            {
                if (companyManager.IsCompanyExistsById(id))
                {
                    Company company = companyManager.GetCompanyById(id);
                    return View(company);
                }
                else
                {
                    return HttpNotFound();
                }
                
            }
            else
            {
                return HttpNotFound();
            }    
        }

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            if (Request.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    company.ActionDate = DateTime.Now.ToString();
                    company.ActionType = ActionType.Update;
                    company.ActionBy = ActionType.User;

                    ViewBag.Response = companyManager.UpdateCompany(company);
                }
                else
                {
                    ViewBag.Response = 3;
                }

                ModelState.Clear();
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }
	}
}