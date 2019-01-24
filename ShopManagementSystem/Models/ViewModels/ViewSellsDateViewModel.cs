using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopManagementSystem.Models.ViewModels
{
    public class ViewSellsDateViewModel
    {
        [Required(ErrorMessage = "Select from date")]
        public string FromDate { get; set; }

        [Required(ErrorMessage = "Select to date")]
        public string ToDate { get; set; }
    }
}