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


        //đơn nhập hàng

        public ActionResult danh_sach_don_nhap_hang(string search)
        {
            List<don_nhap_hang> li_dnh = db.Database.SqlQuery<don_nhap_hang>("tim_kiem_don_nhap_hang @search", new SqlParameter("@search", search ?? (object)DBNull.Value)).ToList();
            return View(li_dnh);
        }
        public ActionResult chi_tiet_dnh(string id)

        {
            don_nhap_hang dnh = db.don_nhap_hang.FirstOrDefault(m => m.id_hoa_don_nhap == id);
            return View(dnh);
        }
        //public ActionResult add_dnh()
        //{
        //    ViewBag.idnsx=new SelectList(db.)
        //    return View();
        //}
        [HttpPost]
        public ActionResult add_dnh([Bind(Include = "id_nsx,id_chu_kho,ngay_nhap_hang")] don_nhap_hang dnh)
        {
            dnh.ngay_nhap_hang = DateTime.Now;
            db.Database.ExecuteSqlCommand("insert_dnh @id_nsx,@id_chu_kho,@ngay_nhap_hang",
                new SqlParameter("@id_nsx", dnh.id_nsx),
                new SqlParameter("@id_chu_kho", dnh.id_chu_kho),
                new SqlParameter("@ngay_nhap_hang", dnh.ngay_nhap_hang)
                );
            return RedirectToAction("danh_sach_don_nhap_hang");
        }
        //Xe đạp
        public ActionResult danh_sach_xe_dap(string search)
        {
            List<xe> li_xe = db.Database.SqlQuery<xe>("tim_kiem_xe @search", new SqlParameter("search", search ?? (object)DBNull.Value)).ToList();
            return View(li_xe);
        }
        public ActionResult add_xe()
        {
            ViewBag.id_hang_xe = new SelectList(db.hang_xe, "id_hang_xe", "ten_hang");
            ViewBag.id_loai_xe = new SelectList(db.loai_xe, "id_loai_xe", "ten_loai");
            ViewBag.id_nsx = new SelectList(db.nsxes, "id_nsx", "ten_nsx");
            return View();
        }
        [HttpPost]
        public ActionResult add_xe(xe x, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImages/"), pic);
                file.SaveAs(path);
            }
            x.anh_xe = pic;

            db.Database.ExecuteSqlCommand("add_xe @ten_xe,@id_hang_xe,@id_loai_xe,@model_year,@gia_ban,@id_nsx,@anh_xe",
                new SqlParameter("@ten_xe", x.ten_xe),
                new SqlParameter("@id_hang_xe", x.id_hang_xe),
                new SqlParameter("@id_loai_xe", x.id_loai_xe),
                new SqlParameter("@model_year", x.model_year),
                new SqlParameter("@gia_ban", x.gia_ban),
                new SqlParameter("@id_nsx", x.id_nsx),
                new SqlParameter("@anh_xe", x.anh_xe)
                );
            return RedirectToAction("danh_sach_xe_dap");
        }
        public ActionResult danh_sach_don_dat_hang(string search)
        {
            List<dat_hang> li_dh = db.Database.SqlQuery<dat_hang>("danh_sach_dat_hang @search", new SqlParameter("@search", search ?? (object)DBNull.Value)).ToList();
            //List<dat_hang> li_dh = db.dat_hang.ToList();
            return View(li_dh);
        }
        public ActionResult tim_kiem_thong_tin(string id_khach_hang, string id_don_hang)
        {
            List<chi_tiet_don_dat_hang> ct = db.Database.SqlQuery<chi_tiet_don_dat_hang>("thong_tin_don_hang @ma_khach_hang,@ma_don_hang",
                new SqlParameter("@ma_khach_hang", id_khach_hang),
                new SqlParameter("@ma_don_hang", id_don_hang)
                ).ToList();
            return View(ct);
        }

        public ActionResult tim_kiem_xe_theo_hang(string ten_hang)
        {
            List<xe> li_xe = db.Database.SqlQuery<xe>("tim_kiem_xe_theo_hang @ten_hang", new SqlParameter("@ten_hang", ten_hang)).ToList();
            return View(li_xe);
        }
       
    }
}