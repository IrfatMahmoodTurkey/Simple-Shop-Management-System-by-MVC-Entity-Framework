using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopManagementSystem.Gateway;
using ShopManagementSystem.Models;
using ShopManagementSystem.Models.ViewModels;

namespace ShopManagementSystem.Manager
{
    public class StockOutManager
    {
        private StockOutGateway stockOutGateway;
        private ItemGateway itemGateway;

        public StockOutManager()
        {
            stockOutGateway = new StockOutGateway();
            itemGateway = new ItemGateway();
        }

        public decimal ComputePriceWithDecimal(int discount, int itemId, int quantity)
        {
            decimal sellPrice = itemGateway.GetItemSellPriceByItemId(itemId);

            decimal totalPrice = sellPrice*quantity;
            decimal priceWithDiscount = totalPrice - ((totalPrice*discount)/100);

            return priceWithDiscount;
        }

        public List<CartViewModel> GetAndViewAllCarts(List<Cart> carts)
        {
            return stockOutGateway.GetAndViewCart(carts);
        }

      

        public int SaveOnSell(List<Sell> sells)
        {
            int checkInsert = stockOutGateway.SaveOnSells(sells);

            if (checkInsert == 1)
            {
                return 100;
            }
            else
            {
                return 101;
            }
        }

        public List<SellsViewModels> GetSalesBetweenDate(ViewSellsDateViewModel date)
        {
            return stockOutGateway.GetSellsByDate(date);
        }

        public decimal GetTotalPriceByDateRange(ViewSellsDateViewModel date)
        {
            List<SellsViewModels> sells = stockOutGateway.GetSellsByDate(date);
            decimal result = 0.00m;

            foreach (SellsViewModels model in sells)
            {
                result = result + model.Price;
            }

            return result;
        }

        public decimal GetBasePriceByProduct(ViewSellsDateViewModel date)
        {
            List<SellsViewModels> sells = stockOutGateway.GetSellsByDate(date);
            List<decimal> allPrice = new List<decimal>();
            decimal totalPrice = 0.00m;

            foreach (SellsViewModels model in sells)
            {
                decimal mainPrice = itemGateway.GetItemPrice(model.ItemId);
                totalPrice = mainPrice*model.Quantity;
                allPrice.Add(totalPrice);
            }

            return allPrice.Sum();
        }

        public int SaveOnDamaged(List<Damaged> damageds)
        {
            int checkInsert = stockOutGateway.SaveOnDamages(damageds);

            if (checkInsert == 1)
            {
                return 100;
            }
            else
            {
                return 101;
            }
        }

        public int SaveOnLost(List<Loss> loss)
        {
            int checkInsert = stockOutGateway.SaveOnLost(loss);

            if (checkInsert == 1)
            {
                return 100;
            }
            else
            {
                return 101;
            }
        }

        public List<StockOutViewModels> GetSoldItems()
        {
            return stockOutGateway.GetSoldItems();
        }

        public List<StockOutViewModels> GetDamagedItems()
        {
            return stockOutGateway.GetDamagedItems();
        }

        public List<StockOutViewModels> GetLostItems()
        {
            return stockOutGateway.GetLostItems();
        } 
    }
}