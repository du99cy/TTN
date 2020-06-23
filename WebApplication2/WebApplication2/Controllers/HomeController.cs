using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using WebApplication2.Database;
using WebApplication2.Models.Home;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        BikeStoreShoppingEntities db = new BikeStoreShoppingEntities();
        public ActionResult Index(string search, int? page)
        {
            Session["session_cart"] = true;
            Session["session_add_cart_index"] = true;
            IPagedList<xe> li_san_pham = db.Database.SqlQuery<xe>("tim_san_pham @search", new SqlParameter("@search", search ?? (object)DBNull.Value)).ToList().ToPagedList(page ?? 1, 32);
            return View(li_san_pham);
        }
        public ActionResult Details(string id)
        {
            xe x = db.xes.FirstOrDefault(m => m.id_xe == id);
            Session["session_add_cart_index"] = false;
            return View(x);
        }
        public ActionResult add_to_cart(string productId, string buyNow, int quantity = 1)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                if (Session["cart"] == null)
                {
                    List<Items> li_in_cart = new List<Items>();

                    Items i = new Items()
                    {
                        product = db.xes.FirstOrDefault(m => m.id_xe == productId),
                        quantity = quantity
                    };
                    li_in_cart.Add(i);
                    Session["cart"] = li_in_cart;

                }
                else
                {
                    List<Items> li_in_cart = (List<Items>)Session["cart"];
                    bool isDuplicate = false;
                    for (int i = 0; i < li_in_cart.Count(); ++i)
                    {
                        if (li_in_cart[i].product.id_xe == productId)
                        {
                            li_in_cart[i].quantity += quantity;
                            isDuplicate = true;
                            break;
                        }

                    }
                    if (!isDuplicate)
                    {
                        li_in_cart.Add(new Items()
                        {
                            product = db.xes.FirstOrDefault(m => m.id_xe == productId),
                            quantity = quantity
                        });
                    }
                    Session["cart"] = li_in_cart;
                }
                if (buyNow != null)
                {
                    return RedirectToAction("view_product_in_cart");
                }
                if ((bool)Session["session_add_cart_index"])
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Details", new { id = productId });


           }
        }
        public ActionResult remove_from_cart(string productId)
        {
            List<Items> li_in_cart = (List<Items>)Session["cart"];
            foreach (var i in li_in_cart)
            {
                if (i.product.id_xe == productId)
                {
                    li_in_cart.Remove(i);
                    break;
                }
            }
            if ((bool)Session["session_cart"] == true)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("view_product_in_cart");
        }
        public ActionResult view_product_in_cart()
        {
            Session["session_cart"] = false;
            return View();
        }
        public ActionResult increase_quantity_in_cart(string productId)
        {
            List<Items> li_in_cart = (List<Items>)Session["cart"];
            foreach (var item in li_in_cart)
            {
                if (item.product.id_xe == productId)
                {
                    item.quantity += 1;
                    break;
                }
            }
            Session["cart"] = li_in_cart;
            return RedirectToAction("view_product_in_cart");
        }
        public ActionResult decrease_quantity_in_cart(string productId)
        {
            List<Items> li_in_cart = (List<Items>)Session["cart"];
            foreach (var item in li_in_cart)
            {
                if (item.product.id_xe == productId)
                {
                    if (item.quantity > 0)
                    {
                        if(--item.quantity ==0)
                        {
                            li_in_cart.Remove(item);
                        }
                        
                    }
                    
                    break;
                }
            }
            Session["cart"] = li_in_cart;
            return RedirectToAction("view_product_in_cart");
        }
    }
}