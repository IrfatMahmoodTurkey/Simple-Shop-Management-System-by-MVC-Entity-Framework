using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ShopManagementSystem.Models;
using ShopManagementSystem.Models.ViewModels;

namespace ShopManagementSystem.Gateway
{
    public class HomeGateway:CommonContext
    {
        
        public int GetTotalItems()
        {
             return Context.Items.Count();
        }

        public int GetTotalStockIn()
        {
            return Context.StockIns.Sum(x=>x.StockInQuantity);
        }


        public int GetTotalStockOut()
        {
            int sells = Context.Sells.Sum(x=>x.Quantity);
            int damaged = Context.Damaged.Sum(x => x.Quantity);
            int lost = Context.Losses.Sum(x => x.Quantity);

            return sells + damaged + lost;
        }

        public int GetSoldItemByMonth(DateTime from, DateTime to)
        {
            int total = Context.Sells.Where(s => s.Date >= from && s.Date <= to).Sum(x=>x.Quantity);
            return total;
        }

        public int GetDamagedItemByMonth(DateTime from, DateTime to)
        {
            int total = Context.Damaged.Where(s => s.Date >= from && s.Date <= to).Sum(x=>x.Quantity);
            return total;
        }

        public int GetLostItemByMonth(DateTime from, DateTime to)
        {
            int total = Context.Losses.Where(s => s.Date >= from && s.Date <= to).Sum(x=>x.Quantity);
            return total;
        }

        public decimal GetTotalSoldItemCost(DateTime fromDate, DateTime toDate)
        {
            var query = Context.Sells.Where(s => s.Date >= fromDate && s.Date <= toDate);
            decimal basePrice = 0;
            decimal soldPrice = 0;

            foreach (var items in query)
            {
                int itemId = items.ItemId;
                decimal mainPrice = GetItemBasePrice(itemId, items.Quantity);
                basePrice = basePrice + mainPrice;
                soldPrice = soldPrice + items.Price;
            }


            return soldPrice - basePrice;
        }


        public decimal GetItemBasePrice(int itemId, int quantity)
        {
            Item item = Context.Items.Where(i => i.Id == itemId).FirstOrDefault();
            decimal price = item.Price*quantity;
            return price;
        }

        public List<Item> GetAllItems()
        {
            return Context.Items.ToList();
        }

        public int GetCountBelowReorder()
        {
            List<Item> items = GetAllItems();
            int count = 0;

            foreach (Item item in items)
            {
                if (Context.Items.Any(i => i.Id == item.Id && i.ReorderLevel > item.Quantity))
                {
                    count++;
                }         
            }

            return count;
        }

        public List<ItemViewModel> GetBelowReorderViewItems()
        {
            List<Item> items = GetAllItems();
            List<ItemViewModel> item = new List<ItemViewModel>();

            foreach (Item data in items)
            {
                var query = Context.Items.Where(i => i.Id == data.Id && i.ReorderLevel > data.Quantity).Include(x=>x.Company).Include(x=>x.Category)
                    .Select(c => new
                    {
                        ItemName = c.ItemName,
                        CompanyName = c.Company,
                        CategoryName = c.Category,
                        ReorderLevel = c.ReorderLevel,
                        Price = c.Price,
                        Quantity = c.Quantity
                    });

                foreach (var filterData in query)
                {
                    ItemViewModel itemViewModel = new ItemViewModel();

                    itemViewModel.ItemName = filterData.ItemName;
                    itemViewModel.CompanyName = filterData.CompanyName.Name;
                    itemViewModel.CategoryName = filterData.CategoryName.Name;
                    itemViewModel.ReorderLevel = filterData.ReorderLevel;
                    itemViewModel.BasePrice = filterData.Price;
                    itemViewModel.Quantity = filterData.Quantity;

                    item.Add(itemViewModel);
                }
            }

            return item;
        }

        public decimal GetTotalSoldPrice(DateTime fromDate, DateTime toDate)
        {
            decimal total = 0.00m;
            var query = Context.Sells.Where(s => s.Date >= fromDate && s.Date <= toDate);

            foreach (var item in query)
            {
                total = total + item.Price;
            }   
            return total;
        }

        public List<StockOutViewModels> GetMonthlySoldItems(DateTime fromDate, DateTime toDate)
        {
            List<StockOutViewModels> stockOutViewModelss = new List<StockOutViewModels>();
            var query = Context.Sells.Where(s => s.Date >= fromDate && s.Date <= toDate).Include(x=>x.Item).Include(x=>x.Company)
                .Select(i => new
                {
                    ItemName = i.Item,
                    CompanyName = i.Company,
                    Price = i.Price,
                    Discount = i.Discount,
                    Date = i.Date,
                    Quantity = i.Quantity
                });

            foreach (var item in query)
            {
                StockOutViewModels model = new StockOutViewModels();

                model.ItemName = item.ItemName.ItemName;
                model.CompanyName = item.CompanyName.Name;
                model.Discount = item.Discount.ToString() + "%";
                model.Price = item.Price.ToString();
                model.Date = item.Date.ToString("D");
                model.Quantity = item.Quantity.ToString();

                stockOutViewModelss.Add(model);
            }

            return stockOutViewModelss;
        }

    }
}