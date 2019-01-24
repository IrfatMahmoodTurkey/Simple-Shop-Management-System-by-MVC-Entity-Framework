using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopManagementSystem.Models
{
    public class StockIn
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Select Company")]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required(ErrorMessage = "Select Item")]
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        [Required(ErrorMessage = "Enter Date")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Enter Stock In Quantity")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Quantity can not be zero or negative")]
        public int StockInQuantity { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public decimal Total { get; set; }
        public string ActionType { get; set; }
        public string ActionDate { get; set; }
        public string ActionBy { get; set; }
    }
}