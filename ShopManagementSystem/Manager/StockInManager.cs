using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopManagementSystem.Gateway;
using ShopManagementSystem.Models;

namespace ShopManagementSystem.Manager
{
    public class StockInManager
    {
        private StockInGateway stockInGateway;
        private ItemGateway itemGateway;

        public StockInManager()
        {
            stockInGateway = new StockInGateway();
            itemGateway = new ItemGateway();
        }

        public int AddStockIn(StockIn stockIn)
        {
            stockIn.Total = ComputeTotalPrice(stockIn);

            Item item = itemGateway.GetItemInfoByItemId(stockIn.ItemId);
            item.Quantity = item.Quantity + stockIn.StockInQuantity;

            int rowsAffected1 = itemGateway.UpdateItemsQuantity(item);
            int rowsAffected2 = stockInGateway.AddStockIn(stockIn);

            if (rowsAffected1 > 0 && rowsAffected2 > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public decimal ComputeTotalPrice(StockIn stockIn)
        {
            decimal price = itemGateway.GetItemPrice(stockIn.ItemId);

            decimal totalPrice = price * stockIn.StockInQuantity;

            return totalPrice;
        }
    }
}