using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Database;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        BikeStoreShoppingEntities db = new BikeStoreShoppingEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult danh_sach_hang_xe(string search)
        {

            List<hang_xe> li_hang_xe = db.Database.SqlQuery<hang_xe>("tim_kiem_hang_xe @search", new SqlParameter("@search", search ?? (object)DBNull.Value)).ToList();
            return View(li_hang_xe);
        }
    }
}