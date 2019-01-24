using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopManagementSystem.Models
{
    public class Item
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string SerialNo { get; set; }
        [Required(ErrorMessage = "Select Company")]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        [Required(ErrorMessage = "Select Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required(ErrorMessage = "Enter Item Name")]
        [StringLength(100)]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Enter Reorder Level")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Reorder level can not be negative")]
        public int ReorderLevel { get; set; }
        [Required(ErrorMessage = "Enter Price")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Price can not be zero or negative")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Enter Sell Price")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Price can not be zero or negative")]
        public decimal SellPrice { get; set; }
        public int Quantity { get; set; }
        public string ActionType { get; set; }
        public string ActionDate { get; set; }
        public string ActionBy { get; set; }

        public List<Sell> Sells { get; set; }
    }
}