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
    public class StockOutGateway : CommonContext
    {
        
        public List<CartViewModel> GetAndViewCart(List<Cart> carts)
        {
            List<CartViewModel> cartViewModels = new List<CartViewModel>();

            foreach (var item in carts)
            {
                var query = Context.Items.Where(i => i.Id == item.ItemId)
                    .Select(c => new
                    {
                        ItemId = c.Id,
                        ItemName = c.ItemName,
                        CompanyId = c.CompanyId,
                        CompanyName = c.Company.Name,
                        Quantity = c.Quantity,
                        Price = c.SellPrice,
                    }).FirstOrDefault();


                CartViewModel cartViewModel = new CartViewModel();

                cartViewModel.ItemId = query.ItemId;
                cartViewModel.CompanyId = query.CompanyId;
                cartViewModel.Quantity = item.Quantity;
                cartViewModel.Discount = item.Discount;
                cartViewModel.Price = item.Price;
                cartViewModel.ItemName = query.ItemName;
                cartViewModel.CompanyName = query.CompanyName;

                cartViewModels.Add(cartViewModel);

            }



            return cartViewModels;
        }


        public int SaveOnSells(List<Sell> sells)
        {
            int sellCount = sells.Count;
            int count = 0;

            foreach (Sell items in sells)
            {
                Sell sell = new Sell();

                sell.ItemId = items.ItemId;
                sell.CompanyId = items.CompanyId;
                sell.Quantity = items.Quantity;
                sell.Price = items.Price;
                sell.Discount = items.Discount;
                sell.Date = items.Date;
                sell.ActionDate = items.ActionDate;
                sell.ActionType = items.ActionType;
                sell.ActionBy = items.ActionBy;


                Context.Sells.Add(sell);
                int rowsAffected = Context.SaveChanges();

                Item item = Context.Items.Where(i => i.Id == sell.ItemId).FirstOrDefault();
                item.Quantity = item.Quantity - sell.Quantity;

                Context.Items.AddOrUpdate(item);
                int rowsAffected2 = Context.SaveChanges();

                if (rowsAffected > 0 && rowsAffected2 > 0)
                {
                    count++;
                }
            }

            if (count == sellCount)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<SellsViewModels> GetSellsByDate(ViewSellsDateViewModel date)
        {
            List<SellsViewModels> viewModelses = new List<SellsViewModels>();

            DateTime fromDate = DateTime.Parse(date.FromDate);
            DateTime toDate = DateTime.Parse(date.ToDate);

            var query = Context.Sells.Where(c => c.Date >= fromDate && c.Date <= toDate)
                .GroupBy(c => c.ItemId).Select(c => new
                {
                    ItemId = c.Key,
                    ItemName = c.Select(s => s.Item.ItemName).FirstOrDefault(),
                    CompanyName = c.Select(s => s.Company.Name).FirstOrDefault(),
                    Quantity = c.Sum(s => s.Quantity),
                    TotalPrice = c.Sum(s => s.Price)
                });

            foreach (var items in query)
            {
                SellsViewModels viewModels = new SellsViewModels();

                viewModels.ItemId = items.ItemId;
                viewModels.ItemName = items.ItemName;
                viewModels.CompanyName = items.CompanyName;
                viewModels.Quantity = items.Quantity;
                viewModels.Price = items.TotalPrice;

                viewModelses.Add(viewModels);
            }

            return viewModelses;
        }



        public int SaveOnDamages(List<Damaged> damageds)
        {
            int sellCount = damageds.Count;
            int count = 0;

            foreach (Damaged items in damageds)
            {
                Damaged damaged = new Damaged();

                damaged.ItemId = items.ItemId;
                damaged.CompanyId = items.CompanyId;
                damaged.Quantity = items.Quantity;
                damaged.Price = items.Price;
                damaged.Discount = items.Discount;
                damaged.Date = items.Date;
                damaged.ActionDate = items.ActionDate;
                damaged.ActionType = items.ActionType;
                damaged.ActionBy = items.ActionBy;


                Context.Damaged.Add(damaged);
                int rowsAffected = Context.SaveChanges();

                Item item = Context.Items.Where(i => i.Id == damaged.ItemId).FirstOrDefault();
                item.Quantity = item.Quantity - damaged.Quantity;

                Context.Items.AddOrUpdate(item);
                int rowsAffected2 = Context.SaveChanges();

                if (rowsAffected > 0 && rowsAffected2 > 0)
                {
                    count++;
                }
            }

            if (count == sellCount)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int SaveOnLost(List<Loss> loss)
        {
            int sellCount = loss.Count;
            int count = 0;

            foreach (Loss items in loss)
            {
                Loss lossed = new Loss();

                lossed.ItemId = items.ItemId;
                lossed.CompanyId = items.CompanyId;
                lossed.Quantity = items.Quantity;
                lossed.Price = items.Price;
                lossed.Discount = items.Discount;
                lossed.Date = items.Date;
                lossed.ActionDate = items.ActionDate;
                lossed.ActionType = items.ActionType;
                lossed.ActionBy = items.ActionBy;


                Context.Losses.Add(lossed);
                int rowsAffected = Context.SaveChanges();

                Item item = Context.Items.Where(i => i.Id == lossed.ItemId).FirstOrDefault();
                item.Quantity = item.Quantity - lossed.Quantity;

                Context.Items.AddOrUpdate(item);
                int rowsAffected2 = Context.SaveChanges();

                if (rowsAffected > 0 && rowsAffected2 > 0)
                {
                    count++;
                }
            }

            if (count == sellCount)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<StockOutViewModels> GetSoldItems()
        {
            List<StockOutViewModels> stockOutViewModelss = new List<StockOutViewModels>();
            var query = Context.Sells.Include(x => x.Item).Include(x => x.Company)
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

        public List<StockOutViewModels> GetDamagedItems()
        {
            List<StockOutViewModels> stockOutViewModelss = new List<StockOutViewModels>();
            var query = Context.Damaged.Include(x => x.Item).Include(x => x.Company)
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

        public List<StockOutViewModels> GetLostItems()
        {
            List<StockOutViewModels> stockOutViewModelss = new List<StockOutViewModels>();
            var query = Context.Losses.Include(x => x.Item).Include(x => x.Company)
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