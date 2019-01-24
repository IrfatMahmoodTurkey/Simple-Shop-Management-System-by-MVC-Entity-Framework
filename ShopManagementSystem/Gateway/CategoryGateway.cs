using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ShopManagementSystem.Models;

namespace ShopManagementSystem.Gateway
{
    public class CategoryGateway:CommonContext
    {
        public int Add(Category category)
        {
            Context.Categories.Add(category);
            int rowsAffected = Context.SaveChanges();

            return rowsAffected;
        }

        public bool IsCategoryExistsById(int id)
        {
            bool isExists = Context.Categories.Any(c => c.Id == id);
            return isExists;
        }

        public bool IsCategoryExists(Category category)
        {
            bool isExists = Context.Categories.Any(c => c.Name == category.Name);
            return isExists;
        }

        public List<Category> GetAllCategories()
        {
            return Context.Categories.OrderByDescending(c => c.Id).ToList();
        }

        public Category GetCategoryById(int id)
        {
            return Context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public int UpdateCategory(Category category)
        {
            Context.Categories.AddOrUpdate(category);
            int rowsAffected = Context.SaveChanges();

            return rowsAffected;
        }
    }
}