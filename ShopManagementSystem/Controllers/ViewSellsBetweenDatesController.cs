using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopManagementSystem.Manager;
using ShopManagementSystem.Models.ViewModels;

namespace ShopManagementSystem.Controllers
{
    public class ViewSellsBetweenDatesController : Controller
    {
        private StockOutManager stockOutManager;

        public ViewSellsBetweenDatesController()
        {
            stockOutManager = new StockOutManager();
        }
        //
        // GET: /ViewSellsBetweenDates/
        [HttpGet]
        public ActionResult ViewSellsBetweenDates()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult ViewSellsBetweenDates(ViewSellsDateViewModel sells)
        {
            if (Request.IsAuthenticated)
            {
                DateTime fromDate = DateTime.Parse(sells.FromDate);
                DateTime toDate = DateTime.Parse(sells.ToDate);

                if (ModelState.IsValid)
                {
                    if (fromDate > toDate)
                    {
                        ViewBag.Message = 404;
                    }
                    else
                    {
                        ViewBag.Response = stockOutManager.GetSalesBetweenDate(sells);
                        decimal sellPrice = stockOutManager.GetTotalPriceByDateRange(sells);
                        ViewBag.SellPrice = sellPrice;
                        decimal basePrice = stockOutManager.GetBasePriceByProduct(sells);
                        ViewBag.MainPrice = basePrice;
                        ViewBag.Profit = sellPrice - basePrice;
                    }
                }
                else
                {
                    ViewBag.Message = 0;
                }

                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }
	}
}