using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagementSystem.Models.ViewModels
{
    public class CartViewModel
    {
        public int ItemId { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal Price { get; set; }
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public string CustomerRegNo { get; set; }
    }
}