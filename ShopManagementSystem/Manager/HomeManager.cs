using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopManagementSystem.Gateway;
using ShopManagementSystem.Models.ViewModels;

namespace ShopManagementSystem.Manager
{
    public class HomeManager
    {
        private HomeGateway homeGateway;

        public HomeManager()
        {
            homeGateway = new HomeGateway();
        }

        public int GetItem()
        {
            return homeGateway.GetTotalItems();
        }

        public int GetStockIn()
        {
            return homeGateway.GetTotalStockIn();
        }

        public int GetStockOut()
        {
            return homeGateway.GetTotalStockOut();
        }

        public int GetMothlySold()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            int last = DateTime.DaysInMonth(year, month);

            string startDate = "01/" + month + "/" + year;
            string lastDate = last+"/" + month + "/" + year;

            DateTime fromDate = DateTime.Parse(startDate);
            DateTime toDate = DateTime.Parse(lastDate);

            return homeGateway.GetSoldItemByMonth(fromDate, toDate);
        }

        public int GetMothlyDamaged()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            int last = DateTime.DaysInMonth(year, month);

            string startDate = "01/" + month + "/" + year;
            string lastDate = last + "/" + month + "/" + year;

            DateTime fromDate = DateTime.Parse(startDate);
            DateTime toDate = DateTime.Parse(lastDate);

            return homeGateway.GetDamagedItemByMonth(fromDate, toDate);
        }

        public int GetMothlyLost()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            int last = DateTime.DaysInMonth(year, month);

            string startDate = "01/" + month + "/" + year;
            string lastDate = last + "/" + month + "/" + year;

            DateTime fromDate = DateTime.Parse(startDate);
            DateTime toDate = DateTime.Parse(lastDate);

            return homeGateway.GetLostItemByMonth(fromDate, toDate);
        }

        public decimal GetTotalSoldItemCost()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            int last = DateTime.DaysInMonth(year, month);

            string startDate = "01/" + month + "/" + year;
            string lastDate = last + "/" + month + "/" + year;

            DateTime fromDate = DateTime.Parse(startDate);
            DateTime toDate = DateTime.Parse(lastDate);

            return homeGateway.GetTotalSoldItemCost(fromDate, toDate);
        }

        public int GetReorderBelowCount()
        {
            return homeGateway.GetCountBelowReorder();
        }

        public List<ItemViewModel> GetBelowReorderViewItems()
        {
            return homeGateway.GetBelowReorderViewItems();
        }

        public decimal CalculateTotalByMonth(int month, int year)
        {
            decimal total = 0.0m;

            int last = DateTime.DaysInMonth(year, month);

            string startDate = "01/" + month + "/" + year;
            string lastDate = last + "/" + month + "/" + year;

            DateTime fromDate = DateTime.Parse(startDate);
            DateTime toDate = DateTime.Parse(lastDate);

            total = homeGateway.GetTotalSoldPrice(fromDate, toDate);

            return total;
        }

        public int CalculatePercentageProfitByMonth(int month, int year)
        {

            int last = DateTime.DaysInMonth(year, month);

            string startDate = "01/" + month + "/" + year;
            string lastDate = last + "/" + month + "/" + year;

            DateTime fromDate = DateTime.Parse(startDate);
            DateTime toDate = DateTime.Parse(lastDate);

            decimal profit = homeGateway.GetTotalSoldItemCost(fromDate, toDate);
            decimal total = homeGateway.GetTotalSoldPrice(fromDate, toDate);
            int percentageInt = 0;

            if (total != 0)
            {
                decimal percentage = (profit * 100) / total;
                percentageInt = Convert.ToInt32(percentage);
            }

            return percentageInt;
        }

        public List<StockOutViewModels> GetMonthlySoldItems()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            int last = DateTime.DaysInMonth(year, month);

            string startDate = "01/" + month + "/" + year;
            string lastDate = last + "/" + month + "/" + year;

            DateTime fromDate = DateTime.Parse(startDate);
            DateTime toDate = DateTime.Parse(lastDate);

            return homeGateway.GetMonthlySoldItems(fromDate, toDate);
        }
    }
}