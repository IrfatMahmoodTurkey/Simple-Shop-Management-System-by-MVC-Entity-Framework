using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagementSystem.Models.ViewModels
{
    public class SellsViewModels
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public int Quantity { get; set; }
        public decimal Price{ get; set; }
    }
}