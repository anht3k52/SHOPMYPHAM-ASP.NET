using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnangcao1.Models;

namespace webnangcao1.Controllers
{
    public class xemdonhangController : Controller
    {
        private quanlyshopEntities db = new quanlyshopEntities();
        public ActionResult Index()
        {
            if (Session["Use"] == null || Session["Use"].ToString() == "")
            {
                return RedirectToAction("Index", "dangnhap");
            }
            taikhoan kh = (taikhoan)Session["Use"];
            string mauser = kh.Tentaikhoan;
            var donhangs = db.donhangs.Where(d => d.Tentaikhoan == mauser);
            return View(donhangs.ToList());
        }
        public ActionResult xemchitiet(int? id)
        {
            donhang donhang = db.donhangs.Find(id);
            var chitiet = db.chitietdons.Where(d => d.Madonhang == id).ToList();
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(chitiet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}