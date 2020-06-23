using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Database;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        BikeStoreShoppingEntities db = new BikeStoreShoppingEntities();
        public ActionResult Index(string search, int? page)
        {
            Session["session_cart"] = true;
            Session["session_add_cart_index"] = true;
            PagedList.IPagedList<xe> li_san_pham = db.Database.SqlQuery<xe>("tim_san_pham @search", new SqlParameter("@search", search ?? (object)DBNull.Value)).ToList().ToPagedList(page ?? 1, 32);
            return View(li_san_pham);
        }
        public ActionResult Details(string id)
        {
            xe x = db.xes.FirstOrDefault(m => m.id_xe == id);
            Session["session_add_cart_index"] = false;
            return View(x);
        }
    }
}