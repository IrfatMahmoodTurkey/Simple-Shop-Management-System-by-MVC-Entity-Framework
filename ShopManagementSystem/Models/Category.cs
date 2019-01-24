using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopManagementSystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Enter Category Name")]
        public string Name { get; set; }
        public string ActionType { get; set; }
        public string ActionDate { get; set; }
        public string ActionBy { get; set; }
    }
}