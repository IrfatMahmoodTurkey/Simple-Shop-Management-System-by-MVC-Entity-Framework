using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ShopManagementSystem.Models;
using ShopManagementSystem.Models.ViewModels;
using System.Data.Entity;

namespace ShopManagementSystem.Gateway
{
    public class ItemGateway:CommonContext
    {
        public int AddItem(Item item)
        {
            Context.Items.Add(item);
            int rowsAffected = Context.SaveChanges();
            return rowsAffected;
        }

        public bool IsItemExists(Item item)
        {
            bool isExists =
                Context.Items.Any(
                    x => x.CompanyId == item.CompanyId && x.CategoryId == item.CategoryId && x.ItemName == item.ItemName);
            return isExists;
        }

        
        public List<ItemViewModel> GetAllItems()
        {
            var allItems = Context.Items.Include(x => x.Company).Include(x => x.Category)
                .Select(i => new
                {
                    SerialNo = i.SerialNo,
                    ItemName = i.ItemName,
                    Company = i.Company,
                    Category = i.Category,
                    ReorderLevel = i.ReorderLevel,
                    SellPrice = i.SellPrice,
                    Quantity = i.Quantity
                });

            List<ItemViewModel> itemViewModels = new List<ItemViewModel>();

            foreach (var model in allItems)
            {
                ItemViewModel item = new ItemViewModel();

                item.SerialNo = model.SerialNo;
                item.ItemName = model.ItemName;
                item.CompanyName = model.Company.Name;
                item.CategoryName = model.Category.Name;
                item.ReorderLevel = model.ReorderLevel;
                item.SellPrice = model.SellPrice;
                item.Quantity = model.Quantity;

                itemViewModels.Add(item);
            }

            return itemViewModels;
        }

        public string GetLastSerialNo()
        {
            bool checkItemsIsExists = Context.Items.Any();

            if (checkItemsIsExists)
            {
                Item item = Context.Items.OrderByDescending(x=>x.Id).FirstOrDefault();
                return item.SerialNo;
            }
            else
            {
                return "ITM-1000";
            }
        }

        public List<Item> GetItemByCompanyId(int id)
        {
            return Context.Items.Where(x => x.CompanyId == id).ToList();
        }

        public Item GetItemInfoByItemId(int id)
        {
            return Context.Items.Where(x => x.Id == id).FirstOrDefault();
        }

        public int UpdateItemsQuantity(Item item)
        {
            Context.Items.AddOrUpdate(item);
            int rowsAffected = Context.SaveChanges();
            return rowsAffected;
        }

        public decimal GetItemPrice(int id)
        {
            Item item = Context.Items.Where(x => x.Id == id).FirstOrDefault();
            return item.Price;
        }

        public decimal GetItemSellPriceByItemId(int itemId)
        {
            Item item = Context.Items.Where(i => i.Id == itemId).FirstOrDefault();
            return item.SellPrice;
        }

        public List<ItemViewModel> GetItemByCompanyAndCategory(int companyId, int categoryId)
        {
            List<ItemViewModel> itemViewModels = new List<ItemViewModel>();
            var query = Context.Items.Where(i => i.CategoryId == categoryId && i.CompanyId == companyId)
                .Select(i => new
                {
                    Id = i.Id,
                    ItemName = i.ItemName,
                    SerialNo = i.SerialNo,
                    CompanyName = i.Company.Name,
                    CategoryName = i.Category.Name,
                    ReorderLevel = i.ReorderLevel,
                    BasePrice = i.Price,
                    SellPrice = i.SellPrice,
                    Quantity = i.Quantity
                });

            foreach (var items in query)
            {
                ItemViewModel itemViewModel = new ItemViewModel();

                itemViewModel.Id = items.Id;
                itemViewModel.SerialNo = items.SerialNo;
                itemViewModel.ItemName = items.ItemName;
                itemViewModel.CompanyName = items.CompanyName;
                itemViewModel.CategoryName = items.CategoryName;
                itemViewModel.ReorderLevel = items.ReorderLevel;
                itemViewModel.BasePrice = items.BasePrice;
                itemViewModel.SellPrice = items.SellPrice;
                itemViewModel.Quantity = items.Quantity;

                itemViewModels.Add(itemViewModel);
            }

            return itemViewModels;
        }

        public List<ItemViewModel> GetItemByCompany(int companyId)
        {
            List<ItemViewModel> itemViewModels = new List<ItemViewModel>();
            var query = Context.Items.Where(i => i.CompanyId == companyId)
                .Select(i => new
                {
                    Id = i.Id,
                    ItemName = i.ItemName,
                    SerialNo = i.SerialNo,
                    CompanyName = i.Company.Name,
                    CategoryName = i.Category.Name,
                    ReorderLevel = i.ReorderLevel,
                    BasePrice = i.Price,
                    SellPrice = i.SellPrice,
                    Quantity = i.Quantity
                });

            foreach (var items in query)
            {
                ItemViewModel itemViewModel = new ItemViewModel();

                itemViewModel.Id = items.Id;
                itemViewModel.SerialNo = items.SerialNo;
                itemViewModel.ItemName = items.ItemName;
                itemViewModel.CompanyName = items.CompanyName;
                itemViewModel.CategoryName = items.CategoryName;
                itemViewModel.ReorderLevel = items.ReorderLevel;
                itemViewModel.BasePrice = items.BasePrice;
                itemViewModel.SellPrice = items.SellPrice;
                itemViewModel.Quantity = items.Quantity;

                itemViewModels.Add(itemViewModel);
            }

            return itemViewModels;
        }

        public List<ItemViewModel> GetItemByCategory(int categoryId)
        {
            List<ItemViewModel> itemViewModels = new List<ItemViewModel>();
            var query = Context.Items.Where(i => i.CategoryId == categoryId)
                .Select(i => new
                {
                    Id = i.Id,
                    ItemName = i.ItemName,
                    SerialNo = i.SerialNo,
                    CompanyName = i.Company.Name,
                    CategoryName = i.Category.Name,
                    ReorderLevel = i.ReorderLevel,
                    BasePrice = i.Price,
                    SellPrice = i.SellPrice,
                    Quantity = i.Quantity
                });

            foreach (var items in query)
            {
                ItemViewModel itemViewModel = new ItemViewModel();

                itemViewModel.Id = items.Id;
                itemViewModel.SerialNo = items.SerialNo;
                itemViewModel.ItemName = items.ItemName;
                itemViewModel.CompanyName = items.CompanyName;
                itemViewModel.CategoryName = items.CategoryName;
                itemViewModel.ReorderLevel = items.ReorderLevel;
                itemViewModel.BasePrice = items.BasePrice;
                itemViewModel.SellPrice = items.SellPrice;
                itemViewModel.Quantity = items.Quantity;

                itemViewModels.Add(itemViewModel);
            }

            return itemViewModels;
        } 

    }
}