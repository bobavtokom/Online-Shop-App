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
            if (Session["Cart"] == null) {

            List<Item> cart = new List<Item>();
            var product = context.Tbl_Product.Find(productId);
            cart.Add(new Item (){
                Product = product,
                Quantity = 1
            });
            Session["Cart"] = cart;
            } else {
                List<Item> cart = (List<Item>)Session["Cart"];
                var product = context.Tbl_Product.Find(productId);
                cart.Add(new Item() {
                    Product = product,
                    Quantity = 1
                });
                Session["Cart"] = cart;
            }
            return Redirect ("Index");
        }
        public ActionResult RemoveFromCart (int productId) {

            List<Item> cart = (List<Item>)Session["Cart"];
            foreach (var item in cart) {
                if (item.Product.ProductId == productId) {
                cart.Remove(item);}
                break;
            }
            Session["Cart"] = cart;
            return Redirect ("Index");
        }
        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}