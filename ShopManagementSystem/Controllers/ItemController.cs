using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopManagementSystem.Manager;
using ShopManagementSystem.Models;
using ShopManagementSystem.Models.ViewModels;
using ShopManagementSystem.Utility;

namespace ShopManagementSystem.Controllers
{
    public class ItemController : Controller
    {
        private CompanyManager companyManager;
        private CategoryManager categoryManager;
        private ItemManager itemManager;
        private StockInManager stockInManager;
        private StockOutManager stockOutManager;
        public ItemController()
        {
            companyManager = new CompanyManager();
            categoryManager = new CategoryManager();
            itemManager = new ItemManager();
            stockInManager = new StockInManager();
            stockOutManager = new StockOutManager();
        }
        //
        // GET: /Item/
        [HttpGet]
        public ActionResult SaveItem()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.Companies = companyManager.GetCompaniesForDropDown();
                ViewBag.Categories = categoryManager.GetCategoriesForDropDown();
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult SaveItem(Item item)
        {
            if (Request.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    item.ActionDate = DateTime.Now.ToString();
                    item.ActionType = ActionType.Insert;
                    item.ActionBy = ActionType.User;

                    ViewBag.Response = itemManager.AddItem(item);
                }
                else
                {
                    ViewBag.Response = 3;
                }

                ViewBag.Companies = companyManager.GetCompaniesForDropDown();
                ViewBag.Categories = categoryManager.GetCategoriesForDropDown();

                ModelState.Clear();
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult ViewAllItems()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.Items = itemManager.GetAllItems();
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult StockInItem()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.Companies = companyManager.GetCompaniesForDropDown();
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        public JsonResult GetItemByCompany(int id)
        {
            return Json(itemManager.GetItemsByCompanyId(id));
        }

        public JsonResult GetItemInfoByItemId(int itemId)
        {
            Item item = itemManager.GetItemInfoById(itemId);
            int quantity = ReturnCartQuantity(itemId);
            item.Quantity = item.Quantity - quantity;

            return Json(item);
        }

        [HttpPost]
        public ActionResult StockInItem(StockIn stockIn)
        {
            if (Request.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    stockIn.Month = stockIn.Date.Substring(0, 2);
                    stockIn.Year = stockIn.Date.Substring(6, 4);
                    stockIn.ActionDate = DateTime.Now.ToString();
                    stockIn.ActionType = ActionType.Insert;
                    stockIn.ActionBy = ActionType.User;

                    ViewBag.Response = stockInManager.AddStockIn(stockIn);
                }
                else
                {
                    ViewBag.Response = 3;
                }

                ViewBag.Companies = companyManager.GetCompaniesForDropDown();

                ModelState.Clear();
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }


        [HttpGet]
        public ActionResult StockOut()
        {
            if (Request.IsAuthenticated)
            {
                //if (stockOutManager.CheckCartExistsOrNot())
                //{
                //    stockOutManager.DeleteAllCarts();
                //}

                Session["Cart"] = null;
                ViewBag.Companies = companyManager.GetCompaniesForDropDown();
                //ViewBag.Carts = stockOutManager.GetAndViewAllCarts();
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult StockOut(string addButton, Cart cart, string sellButton, string damageButton, string lostButton, FormCollection collections)
        {
            if (Request.IsAuthenticated)
            {
               
                if (addButton != null && sellButton == null && damageButton == null && lostButton == null)
                {
                    if (ModelState.IsValid)
                    {
                        Item item = itemManager.GetItemInfoById(cart.ItemId);
                        int availableQuantity = ReturnCartQuantity(cart.ItemId) - item.Quantity;
                        int available = - availableQuantity - cart.Quantity;

                        if (available > 0)
                        {
                            //ViewBag.Response = stockOutManager.AddOnCart(cart); 
                             AddOnCart(cart);
                        }
                        else
                        {
                            ViewBag.Response = 66;
                        }
                    }
                    else
                    {
                        ViewBag.Response = 5;
                    }
                }
                else if (addButton == null && sellButton != null && damageButton == null && lostButton == null)
                {
                    if (collections.Count > 6)
                    {
                        List<Sell> sells = new List<Sell>();

                        var itemId = Request.Form["items.ItemId"].Split(',').ToArray();
                        var companyId = Request.Form["items.CompanyId"].Split(',').ToArray();
                        var quantity = Request.Form["items.Quantity"].Split(',').ToArray();
                        var price = Request.Form["items.Price"].Split(',').ToArray();
                        var discount = Request.Form["items.Discount"].Split(',').ToArray();

                        for (var i = 0; i < itemId.Length; i++)
                        {
                            Sell sell = new Sell();

                            sell.ItemId = Convert.ToInt32(itemId[i]);
                            sell.CompanyId = Convert.ToInt32(companyId[i]);
                            sell.Quantity = Convert.ToInt32(quantity[i]);
                            sell.Price = Convert.ToDecimal(price[i]);
                            sell.Discount = Convert.ToInt32(discount[i]);
                            sell.Date = DateTime.Now.Date;
                            sell.ActionDate = DateTime.Now.ToString();
                            sell.ActionType = ActionType.Insert;
                            sell.ActionBy = ActionType.User;

                            sells.Add(sell);
                        }


                        ViewBag.Response = stockOutManager.SaveOnSell(sells);
                        Session["Cart"] = null;
                    }
                    else
                    {
                        ViewBag.Response = 404;
                    }

                }
                else if (addButton == null && sellButton == null && damageButton != null && lostButton == null)
                {
                    if (collections.Count > 6)
                    {
                        List<Damaged> damageds = new List<Damaged>();

                        var itemId = Request.Form["items.ItemId"].Split(',').ToArray();
                        var companyId = Request.Form["items.CompanyId"].Split(',').ToArray();
                        var quantity = Request.Form["items.Quantity"].Split(',').ToArray();
                        var price = Request.Form["items.Price"].Split(',').ToArray();
                        var discount = Request.Form["items.Discount"].Split(',').ToArray();

                        for (var i = 0; i < itemId.Length; i++)
                        {
                            Damaged damaged = new Damaged();

                            damaged.ItemId = Convert.ToInt32(itemId[i]);
                            damaged.CompanyId = Convert.ToInt32(companyId[i]);
                            damaged.Quantity = Convert.ToInt32(quantity[i]);
                            damaged.Price = Convert.ToDecimal(price[i]);
                            damaged.Discount = Convert.ToInt32(discount[i]);
                            damaged.Date = DateTime.Now.Date;
                            damaged.ActionDate = DateTime.Now.ToString();
                            damaged.ActionType = ActionType.Insert;
                            damaged.ActionBy = ActionType.User;

                            damageds.Add(damaged);
                        }


                        ViewBag.Response = stockOutManager.SaveOnDamaged(damageds);
                        Session["Cart"] = null;
                    }
                    else
                    {
                        ViewBag.Response = 404;
                    }
                }
                else if (addButton == null && sellButton == null && damageButton == null && lostButton != null)
                {
                    if (collections.Count > 6)
                    {
                        List<Loss> losses = new List<Loss>();

                        var itemId = Request.Form["items.ItemId"].Split(',').ToArray();
                        var companyId = Request.Form["items.CompanyId"].Split(',').ToArray();
                        var quantity = Request.Form["items.Quantity"].Split(',').ToArray();
                        var price = Request.Form["items.Price"].Split(',').ToArray();
                        var discount = Request.Form["items.Discount"].Split(',').ToArray();

                        for (var i = 0; i < itemId.Length; i++)
                        {
                            Loss lost = new Loss();

                            lost.ItemId = Convert.ToInt32(itemId[i]);
                            lost.CompanyId = Convert.ToInt32(companyId[i]);
                            lost.Quantity = Convert.ToInt32(quantity[i]);
                            lost.Price = Convert.ToDecimal(price[i]);
                            lost.Discount = Convert.ToInt32(discount[i]);
                            lost.Date = DateTime.Now.Date;
                            lost.ActionDate = DateTime.Now.ToString();
                            lost.ActionType = ActionType.Insert;
                            lost.ActionBy = ActionType.User;

                            losses.Add(lost);
                        }


                        ViewBag.Response = stockOutManager.SaveOnLost(losses);
                        Session["Cart"] = null;
                    }
                    else
                    {
                        ViewBag.Response = 404;
                    }
                }

                ViewBag.Companies = companyManager.GetCompaniesForDropDown();

                if (Session["Cart"] != null)
                {
                    ViewBag.Carts = GetAllCarts();
                }

                ModelState.Clear();
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        public void AddOnCart(Cart cart)
        {
            if (Session["Cart"] == null)
            {
                List<Cart> carts = new List<Cart>();

                Cart cartModel = new Cart();

                cartModel.ItemId = cart.ItemId;
                cartModel.Quantity = cart.Quantity;
                cartModel.CompanyId = cart.CompanyId;
                cartModel.Discount = cart.Discount;

                decimal priceWithDiscount = stockOutManager.ComputePriceWithDecimal(cart.Discount, cart.ItemId, cart.Quantity);
                cartModel.Price = priceWithDiscount;

                carts.Add(cartModel);

                Session["Cart"] = carts;
            }
            else
            {
                if (IsAlreadyExists(cart.ItemId))
                {
                    UpdateQuantity(cart.ItemId, cart.Quantity);
                }
                else
                {
                    List<Cart> carts = Session["Cart"] as List<Cart>;

                    Cart cartModel = new Cart();

                    cartModel.ItemId = cart.ItemId;
                    cartModel.Quantity = cart.Quantity;
                    cartModel.CompanyId = cart.CompanyId;
                    cartModel.Discount = cart.Discount;

                    decimal priceWithDiscount = stockOutManager.ComputePriceWithDecimal(cart.Discount, cart.ItemId, cart.Quantity);
                    cartModel.Price = priceWithDiscount;


                    carts.Add(cartModel);

                    Session["Cart"] = carts;
                }
            }
        }

        public List<CartViewModel> GetAllCarts()
        {
            List<Cart> carts = Session["Cart"] as List<Cart>;

            return stockOutManager.GetAndViewAllCarts(carts);
        } 

        public bool IsAlreadyExists(int itemId)
        {
            List<Cart> allSessionData = Session["Cart"] as List<Cart>;

            if (allSessionData != null)
            {
                bool isExists = allSessionData.Any(a => a.ItemId == itemId);

                return isExists;
            }
            else
            {
                return false;
            }
        }

        public int ReturnCartQuantity(int itemId )
        {

            if (IsAlreadyExists(itemId))
            {
                List<Cart> allSessionData = Session["Cart"] as List<Cart>;

                Cart cart = allSessionData.Where(a => a.ItemId == itemId).FirstOrDefault();

                return cart.Quantity;
            }
            else
            {
                return 0;
            }
        }

        public void UpdateQuantity(int itemId, int quantity)
        {
            List<Cart> allSessionData = Session["Cart"] as List<Cart>;

            foreach (var item in allSessionData.Where(a => a.ItemId == itemId))
            {
                int totalQuantity = item.Quantity + quantity;
                item.Quantity = totalQuantity;
                decimal priceWithDiscount = stockOutManager.ComputePriceWithDecimal(item.Discount, item.ItemId, totalQuantity);
                item.Price = priceWithDiscount;
            }

            Session["Cart"] = allSessionData;
        }

        [HttpGet]
        public ActionResult SearchItemByCompanyOrCategory()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.Categories = categoryManager.GetCategoriesForDropDown();
                ViewBag.Companies = companyManager.GetCompaniesForDropDown();
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }


        [HttpPost]
        public ActionResult SearchItemByCompanyOrCategory(SearchItemViewModel model)
        {
            if (Request.IsAuthenticated)
            {
                if (model.CompanyId == 0 && model.CategoryId == 0)
                {
                    ViewBag.Response = 0;
                    ViewBag.Items = null;
                }
                else
                {
                    if (model.CompanyId != 0 && model.CategoryId != 0)
                    {
                        ViewBag.Items = itemManager.GetItemByCompanyAndCategory(model.CompanyId, model.CategoryId);
                    }
                    else if (model.CompanyId == 0 && model.CategoryId != 0)
                    {
                        ViewBag.Items = itemManager.GetItemByCategory(model.CategoryId);
                    }
                    else if (model.CompanyId != 0 && model.CategoryId == 0)
                    {
                        ViewBag.Items = itemManager.GetItemByCompany(model.CompanyId);
                    }
                }
                ViewBag.Categories = categoryManager.GetCategoriesForDropDown();
                ViewBag.Companies = companyManager.GetCompaniesForDropDown();

                ModelState.Clear();
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult ViewAllStockOutItems()
        {
            if (Request.IsAuthenticated)
            {
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

    }
}