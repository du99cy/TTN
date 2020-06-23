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

        public ActionResult chi_tiet_hang_xe(string id_hang_xe)
        {
            hang_xe hx = db.hang_xe.FirstOrDefault(m => m.id_hang_xe == id_hang_xe);
            return View(hx);
        }

        public ActionResult add_hang_xe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult add_hang_xe([Bind(Include = "ten_hang")] hang_xe hx)
        {
            db.Database.ExecuteSqlCommand("insert_hang_xe @ten_hang", new SqlParameter("@ten_hang", hx.ten_hang));
            return RedirectToAction("danh_sach_hang_xe");
        }

        public ActionResult edit_hang_xe(string id_hang_xe)
        {
            hang_xe hx = db.hang_xe.FirstOrDefault(m => m.id_hang_xe == id_hang_xe);

            return View(hx);
        }

        [HttpPost]
        public ActionResult edit_hang_xe([Bind(Include = "ten_hang,id_hang_xe")] hang_xe hx)
        {
            db.Database.ExecuteSqlCommand("edit_hang_xe @id_hang_xe,@ten_hang", new SqlParameter("@id_hang_xe", hx.id_hang_xe), new SqlParameter("@ten_hang", hx.ten_hang));
            db.SaveChanges();
            return RedirectToAction("danh_sach_hang_xe");
        }

        [HttpPost]
        public ActionResult delete_hang_xe(string id)
        {
            db.Database.ExecuteSqlCommand("delete_hang_xe @id_hang_xe", new SqlParameter("@id_hang_xe", id));
            db.SaveChanges();
            return RedirectToAction("danh_sach_hang_xe");
        }

        //Loại xe
        public ActionResult danh_sach_loai_xe(string search)
        {

            List<loai_xe> li_loai_xe = db.Database.SqlQuery<loai_xe>("tim_kiem_loai_xe @search", new SqlParameter("@search", search ?? (object)DBNull.Value)).ToList();
            return View(li_loai_xe);
        }

        public ActionResult chi_tiet_loai_xe(string id_loai_xe)
        {
            loai_xe lx = db.loai_xe.FirstOrDefault(m => m.id_loai_xe == id_loai_xe);
            return View(lx);
        }
        public ActionResult add_loai_xe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add_loai_xe([Bind(Include = "ten_loai")] loai_xe lx)
        {
            db.Database.ExecuteSqlCommand("insert_loai_xe @ten_loai", new SqlParameter("@ten_loai", lx.ten_loai));
            return RedirectToAction("danh_sach_loai_xe");
        }
        public ActionResult edit_loai_xe(string id_loai_xe)
        {
            loai_xe lx = db.loai_xe.FirstOrDefault(m => m.id_loai_xe == id_loai_xe);

            return View(lx);
        }
        [HttpPost]
        public ActionResult edit_loai_xe([Bind(Include = "ten_loai,id_loai_xe")] loai_xe lx)
        {
            db.Database.ExecuteSqlCommand("edit_loai_xe @id_loai_xe,@ten_loai", new SqlParameter("@id_loai_xe", lx.id_loai_xe), new SqlParameter("@ten_loai", lx.ten_loai));
            db.SaveChanges();
            return RedirectToAction("danh_sach_loai_xe");
        }
        [HttpPost]
        public ActionResult delete_loai_xe(string id)
        {
            db.Database.ExecuteSqlCommand("delete_loai_xe @id_loai_xe", new SqlParameter("@id_loai_xe", id));
            db.SaveChanges();
            return RedirectToAction("danh_sach_loai_xe");
        }

        //NSX
        public ActionResult danh_sach_nsx(string search)
        {
            List<nsx> li_nsx = db.Database.SqlQuery<nsx>("tim_kiem_nsx @search", new SqlParameter("@search", search ?? (object)DBNull.Value)).ToList();

            return View(li_nsx);

        }
        public ActionResult chi_tiet_nsx(string id)
        {
            nsx n = db.nsxes.FirstOrDefault(m => m.id_nsx == id);
            return View(n);
        }
        public ActionResult add_nsx()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add_nsx([Bind(Include = "ten_nsx,SDT,email,dia_chi")] nsx n)
        {
            db.Database.ExecuteSqlCommand("insert_nsx @ten_nsx,@sdt,@email,@dia_chi",
                new SqlParameter("@ten_nsx", n.ten_nsx),
                new SqlParameter("@sdt", n.SDT),
                new SqlParameter("@email", n.email),
                new SqlParameter("@dia_chi", n.dia_chi)
                );
            return RedirectToAction("danh_sach_nsx");
        }
        public ActionResult Edit_nsx(string id)
        {
            nsx n = db.nsxes.FirstOrDefault(m => m.id_nsx == id);
            return View(n);
        }
        [HttpPost]
        public ActionResult Edit_nsx([Bind(Include = "id_nsx,ten_nsx,SDT,email,dia_chi")] nsx n)
        {
            db.Database.ExecuteSqlCommand("edit_nsx @id_nsx,@ten_nsx,@sdt,@email,@dia_chi",
                new SqlParameter("@id_nsx", n.id_nsx),
                new SqlParameter("@ten_nsx", n.ten_nsx),
                new SqlParameter("@sdt", n.SDT),
                new SqlParameter("@email", n.email),
                new SqlParameter("@dia_chi", n.dia_chi)
                );
            return RedirectToAction("danh_sach_nsx");
        }
        [HttpPost]
        public ActionResult delete_nsx(string id)
        {
            db.Database.ExecuteSqlCommand("delete_nsx @id_nsx", new SqlParameter("@id_nsx", id));
            return RedirectToAction("danh_sach_nsx");
        }
    }
}