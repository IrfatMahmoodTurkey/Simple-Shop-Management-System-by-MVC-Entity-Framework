using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagementSystem.Models.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string SerialNo { get; set; }
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
        public int ReorderLevel { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Quantity { get; set; }
    }
}