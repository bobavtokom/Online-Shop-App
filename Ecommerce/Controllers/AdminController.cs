using Ecommerce.DAL;
using Ecommerce.Models;
using Ecommerce.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class AdminController : Controller {
        public GenericUnitOfWork unitOfWork = new GenericUnitOfWork();
        public List<SelectListItem> GetCategory(){
            List<SelectListItem> list = new List<SelectListItem>();
            var category = unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecords();
            foreach (var item in category) {
                list.Add(new SelectListItem{Value = item.CategoryId.ToString(), Text = item.CategoryName});
            }
            return list;
            }
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Categories() {
           List<Tbl_Category> allCategories = unitOfWork.GetRepositoryInstance<Tbl_Category>()
                .GetAllRecordsIQueryable()
                .Where(i => i.IsDelete == false)
                .ToList();

            return View(allCategories);
        }
        public ActionResult AddCategory() { 
            return UpdateCategory(0);
        }
        public ActionResult UpdateCategory(int categoryId) {
            CategoryDetail categoryDetails;
            if(categoryId != null) {
                categoryDetails = JsonConvert.DeserializeObject<CategoryDetail>(JsonConvert.SerializeObject(unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstOrDefault(categoryId)));
            } else {
                categoryDetails = new CategoryDetail();
            }
            return View("UpdateCategory", categoryDetails);
        }
        public ActionResult Product() { 
            return View(unitOfWork.GetRepositoryInstance<Tbl_Product>().GetProduct()); 
        }
        public ActionResult CategoryEdit(int categoryId) {

            ViewBag.CetegoryList = GetCategory();
            return View(unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstOrDefault(categoryId));
        }
        [HttpPost]
        public ActionResult CategoryEdit(Tbl_Category tbl) {

            unitOfWork.GetRepositoryInstance<Tbl_Category>().Update(tbl);
            return RedirectToAction("Categories");
        }
        public ActionResult ProductEdit(int productId) {

            ViewBag.CetegoryList = GetCategory();
            return View(unitOfWork.GetRepositoryInstance<Tbl_Product>().GetFirstOrDefault(productId)); 
        }
        [HttpPost]
        public ActionResult ProductEdit(Tbl_Product tbl) { 

            tbl.ModifiedDate = DateTime.Now;
            unitOfWork.GetRepositoryInstance<Tbl_Product>().Update(tbl);
            return RedirectToAction("Product");
        }
        public ActionResult ProductAdd(){
            ViewBag.CetegoryList = GetCategory();
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Tbl_Product tbl) {

            tbl.CreatedDate = DateTime.Now; 
            unitOfWork.GetRepositoryInstance<Tbl_Product>().Add(tbl);
            return RedirectToAction("Product");
        }

    }
}