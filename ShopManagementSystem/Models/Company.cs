using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopManagementSystem.Models
{
    public class Company
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Enter Company Name")]
        public string Name { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Enter Company Phone")]
        public string Phone { get; set; }
        public string ActionType { get; set; }
        public string ActionDate { get; set; }
        public string ActionBy { get; set; }
        public List<Sell> Sells { get; set; }
    }
}