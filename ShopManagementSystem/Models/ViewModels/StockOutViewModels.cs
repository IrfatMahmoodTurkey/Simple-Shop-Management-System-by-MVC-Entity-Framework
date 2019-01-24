using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagementSystem.Models.ViewModels
{
    public class StockOutViewModels
    {
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
        public string Date { get; set; }
        public string Price { get; set; }
    }
}