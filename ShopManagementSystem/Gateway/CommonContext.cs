using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopManagementSystem.Models;

namespace ShopManagementSystem.Gateway
{
    public class CommonContext
    {
        public ApplicationDbContext Context { get; set; }

        public CommonContext()
        {
            Context = new ApplicationDbContext();
        }
    }
}