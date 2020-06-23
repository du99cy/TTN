using System;
using System.Collections.Generic;
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
    }
}