using Ecommerce.DAL;
using Ecommerce.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Ecommerce.Models.Home {
    public class HomeIndexViewModel {
        public static GenericUnitOfWork unitOfWork = new GenericUnitOfWork();
        public IEnumerable<Tbl_Product> ListOfProducts { get; set; }
       public HomeIndexViewModel CreateModel() {
            return new HomeIndexViewModel {
                ListOfProducts = unitOfWork.GetRepositoryInstance<Tbl_Product>().GetAllRecords()
            };
        }
    }
}