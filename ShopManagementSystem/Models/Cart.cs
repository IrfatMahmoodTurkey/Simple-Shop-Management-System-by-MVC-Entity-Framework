using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopManagementSystem.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Select One Item")]
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        [Required(ErrorMessage = "Select One Company")]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int AvailableQuantity { get; set; }
     
        [Required(ErrorMessage = "Enter Quantity")]
        [Range(1,Int32.MaxValue, ErrorMessage = "Quantity can not be 0 or negative")]
        public int Quantity { get; set; }

        [Range(0, 100, ErrorMessage = "Discount will be 0% to 100%")]
        public int Discount { get; set; }
        public decimal Price { get; set; }
    }
}