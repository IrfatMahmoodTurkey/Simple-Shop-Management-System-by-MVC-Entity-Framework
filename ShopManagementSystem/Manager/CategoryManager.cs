using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopManagementSystem.Gateway;
using ShopManagementSystem.Models;

namespace ShopManagementSystem.Manager
{
    public class CategoryManager
    {
        private CategoryGateway categoryGateway;

        public CategoryManager()
        {
            categoryGateway = new CategoryGateway();
        }

        public int Add(Category category)
        {
            if (categoryGateway.IsCategoryExists(category))
            {
                return 2;
            }
            else
            {
                int rowsAffected = categoryGateway.Add(category);

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

        public bool IsCategoryExistsById(int id)
        {
            return categoryGateway.IsCategoryExistsById(id);
        }

        public List<Category> GetAllCategories()
        {
            return categoryGateway.GetAllCategories();
        }

        public int UpdateCategory(Category category)
        {
            if (categoryGateway.IsCategoryExists(category))
            {
                return 2;
            }
            else
            {
                int rowsAffected = categoryGateway.UpdateCategory(category);

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

        public Category GetCategoryById(int id)
        {
            return categoryGateway.GetCategoryById(id);
        }

        public List<SelectListItem> GetCategoriesForDropDown()
        {
            List<Category> categories = GetAllCategories();

            List<SelectListItem> listItems =
                categories.ConvertAll(x => new SelectListItem() {Text = x.Name, Value = x.Id.ToString()});

            List<SelectListItem> mainListItems = new List<SelectListItem>();
            mainListItems.Add(new SelectListItem()
            {
                Text = "--Select Category--",
                Value = ""
            });

            mainListItems.AddRange(listItems);

            return mainListItems;
        } 
    }
}