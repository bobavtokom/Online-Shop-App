using Ecommerce.DAL;
using Ecommerce.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers {
    public class HomeController : Controller {
        public dbMyOnlineShoppingEntities context = new dbMyOnlineShoppingEntities();

        public ActionResult Index(string search, int? page) {
            HomeIndexViewModel model = new HomeIndexViewModel();
            return View(model.CreateModel(search, 4, page));
        }

        public ActionResult AddToCart(int productId) {
            var cart = new List<Item>();
            var product = context.Tbl_Product.Find(productId);
            cart.Add(new Item (){
                product = product,
                Quantity = 1
            });
            Session["Cart"] = cart;
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}