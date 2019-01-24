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
    public class CategoryController : Controller
    {
        private CategoryManager categoryManager;

        public CategoryController()
        {
            categoryManager = new CategoryManager();
        }
        //
        // GET: /Category/
        [HttpGet]
        public ActionResult SaveCategory()
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
        public ActionResult SaveCategory(Category category)
        {
            if (Request.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    category.ActionDate = DateTime.Now.ToString();
                    category.ActionType = ActionType.Insert;
                    category.ActionBy = ActionType.User;

                    ViewBag.Response = categoryManager.Add(category);
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
        public ActionResult ViewAllCategories()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.Categories = categoryManager.GetAllCategories();
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
                if (categoryManager.IsCategoryExistsById(id))
                {
                    Category category = categoryManager.GetCategoryById(id);
                    return View(category);
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
        public ActionResult Edit(Category category)
        {
            if (Request.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    category.ActionDate = DateTime.Now.ToString();
                    category.ActionType = ActionType.Update;
                    category.ActionBy = ActionType.User;

                    ViewBag.Response = categoryManager.UpdateCategory(category);
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