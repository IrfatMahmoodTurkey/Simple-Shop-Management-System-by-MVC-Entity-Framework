using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ShopManagementSystem.Manager;

namespace ShopManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private HomeManager homeManager;
        private StockOutManager stockOutManager;
        private ItemManager itemManager;

        public HomeController()
        {
            stockOutManager = new StockOutManager();
            itemManager = new ItemManager();
            homeManager = new HomeManager();
        }
        [HttpGet]
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                string currentUserName = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.UserName = currentUserName;

                ViewBag.Today = DateTime.Now.ToString("D");
                ViewBag.TotalItem = homeManager.GetItem();
                ViewBag.StockOut = homeManager.GetStockOut();
                ViewBag.Profit = homeManager.GetTotalSoldItemCost();
                ViewBag.Below = homeManager.GetReorderBelowCount();
                ViewBag.BelowReorderItems = homeManager.GetBelowReorderViewItems();

                ViewBag.Year = DateTime.Now.Year;
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;

                ViewBag.Jan = homeManager.CalculateTotalByMonth(1, year);
                ViewBag.Feb = homeManager.CalculateTotalByMonth(2, year);
                ViewBag.Mar = homeManager.CalculateTotalByMonth(3, year);
                ViewBag.Apr = homeManager.CalculateTotalByMonth(4, year);
                ViewBag.May = homeManager.CalculateTotalByMonth(5, year);
                ViewBag.Jun = homeManager.CalculateTotalByMonth(6, year);
                ViewBag.Jul = homeManager.CalculateTotalByMonth(7, year);
                ViewBag.Aug = homeManager.CalculateTotalByMonth(8, year);
                ViewBag.Sept = homeManager.CalculateTotalByMonth(9, year);
                ViewBag.Oct = homeManager.CalculateTotalByMonth(10, year);
                ViewBag.Nov = homeManager.CalculateTotalByMonth(11, year);
                ViewBag.Dec = homeManager.CalculateTotalByMonth(12, year);


                if (month == 1)
                {
                    ViewBag.prevTwoMonth = homeManager.CalculatePercentageProfitByMonth(11, year-1);
                    ViewBag.prevMonth = homeManager.CalculatePercentageProfitByMonth(12, year-1);
                    ViewBag.recMonth = homeManager.CalculatePercentageProfitByMonth(month, year);

                    ViewBag.prevTwoMonthName = "November";
                    ViewBag.prevMonthName = "December";
                    ViewBag.MonthName = "January";
                }
                else if (month == 2)
                {
                    ViewBag.prevTwoMonth = homeManager.CalculatePercentageProfitByMonth(12, year - 1);
                    ViewBag.prevMonth = homeManager.CalculatePercentageProfitByMonth(1, year);
                    ViewBag.recMonth = homeManager.CalculatePercentageProfitByMonth(month, year);

                    ViewBag.prevTwoMonthName = "December";
                    ViewBag.prevMonthName = "January";
                    ViewBag.MonthName = "February";
                }
                else
                {
                    ViewBag.prevTwoMonth = homeManager.CalculatePercentageProfitByMonth(month - 2, year - 1);
                    ViewBag.prevMonth = homeManager.CalculatePercentageProfitByMonth(month - 1, year);
                    ViewBag.recMonth = homeManager.CalculatePercentageProfitByMonth(month, year);

                    ViewBag.prevTwoMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month - 2);
                    ViewBag.prevMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month - 1);
                    ViewBag.MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);

                }
                
                ViewBag.MonthlySold = homeManager.GetMonthlySoldItems();

                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult Charts()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.Year = DateTime.Now.Year;
                int year = DateTime.Now.Year;

                ViewBag.Jan = homeManager.CalculateTotalByMonth(1, year);
                ViewBag.Feb = homeManager.CalculateTotalByMonth(2, year);
                ViewBag.Mar = homeManager.CalculateTotalByMonth(3, year);
                ViewBag.Apr = homeManager.CalculateTotalByMonth(4, year);
                ViewBag.May = homeManager.CalculateTotalByMonth(5, year);
                ViewBag.Jun = homeManager.CalculateTotalByMonth(6, year);
                ViewBag.Jul = homeManager.CalculateTotalByMonth(7, year);
                ViewBag.Aug = homeManager.CalculateTotalByMonth(8, year);
                ViewBag.Sept = homeManager.CalculateTotalByMonth(9, year);
                ViewBag.Oct = homeManager.CalculateTotalByMonth(10, year);
                ViewBag.Nov = homeManager.CalculateTotalByMonth(11, year);
                ViewBag.Dec = homeManager.CalculateTotalByMonth(12, year);


                ViewBag.JanPro = homeManager.CalculatePercentageProfitByMonth(1, year);
                ViewBag.FebPro = homeManager.CalculatePercentageProfitByMonth(2, year);
                ViewBag.MarPro = homeManager.CalculatePercentageProfitByMonth(3, year);
                ViewBag.AprPro = homeManager.CalculatePercentageProfitByMonth(4, year);
                ViewBag.MayPro = homeManager.CalculatePercentageProfitByMonth(5, year);
                ViewBag.JunPro = homeManager.CalculatePercentageProfitByMonth(6, year);
                ViewBag.JulPro = homeManager.CalculatePercentageProfitByMonth(7, year);
                ViewBag.AugPro = homeManager.CalculatePercentageProfitByMonth(8, year);
                ViewBag.SeptPro = homeManager.CalculatePercentageProfitByMonth(9, year);
                ViewBag.OctPro = homeManager.CalculatePercentageProfitByMonth(10, year);
                ViewBag.NovPro = homeManager.CalculatePercentageProfitByMonth(11, year);
                ViewBag.DecPro = homeManager.CalculatePercentageProfitByMonth(12, year);

                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult Tables()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.ItemTable = itemManager.GetAllItems();
                ViewBag.Sold = stockOutManager.GetSoldItems();
                ViewBag.Damaged = stockOutManager.GetDamagedItems();
                ViewBag.Losed = stockOutManager.GetLostItems();

                return View();
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        [HttpGet]
        public ActionResult BelowReorderLevel()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.BelowReorderItems = homeManager.GetBelowReorderViewItems();
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        } 

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Help()
        {
            return View();
        }
    }
}