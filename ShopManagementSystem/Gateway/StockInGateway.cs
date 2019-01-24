using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopManagementSystem.Models;

namespace ShopManagementSystem.Gateway
{
    public class StockInGateway:CommonContext
    {
        public int AddStockIn(StockIn stockIn)
        {
            Context.StockIns.Add(stockIn);
            int rowsAffected = Context.SaveChanges();
            return rowsAffected;
        }
    }
}