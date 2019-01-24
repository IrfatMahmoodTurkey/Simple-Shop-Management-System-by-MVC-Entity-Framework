using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopManagementSystem.Models
{
    public class Loss
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        [Required]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Discount { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string ActionType { get; set; }
        public string ActionDate { get; set; }
        public string ActionBy { get; set; }
    }
}