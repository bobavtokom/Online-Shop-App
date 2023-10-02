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
    public class AdminController : Controller
    {
        public GenericUnitOfWork unitOfWork = new GenericUnitOfWork();
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
        public ActionResult ProductEdit(int productId) { 
            return View(unitOfWork.GetRepositoryInstance<Tbl_Product>().GetFirstOrDefault(productId)); 
        }

    }
}