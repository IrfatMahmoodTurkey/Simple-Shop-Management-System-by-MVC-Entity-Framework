using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagementSystem.Utility
{
    public static class ActionType
    {
        public static string Insert { get;private set; }
        public static string Update { get;private set; }
        public static string Delete { get;private set; }
        public static string User { get;private set; }

        static ActionType()
        {
            Insert = "INSERTED";
            Update = "UPDATED";
            Delete = "DELETED";
            User = "ADMIN";
        }
    }
}