using Ecommerce.DAL;
using Ecommerce.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ecommerce.Models.Home {
    public class HomeIndexViewModel {
        public static GenericUnitOfWork unitOfWork = new GenericUnitOfWork();
        public dbMyOnlineShoppingEntities context = new dbMyOnlineShoppingEntities();

        public IEnumerable<Tbl_Product> ListOfProducts { get; set; }
       public HomeIndexViewModel CreateModel(string search) {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter(
                    "@search", search??(object)DBNull.Value)
            };
            IEnumerable<Tbl_Product> data = context.Database.SqlQuery<Tbl_Product>("GetBySearch @search", param).ToList();
            return new HomeIndexViewModel {
                ListOfProducts = data
            };
        }
    }
}