using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using webnangcao1.Models;

namespace webnangcao1.Controllers
{
    public class dangnhapController : Controller
    {
        // GET: dangnhap
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(taikhoan tk)
        {
            quanlyshopEntities db = new quanlyshopEntities();
            var check = db.taikhoans.FirstOrDefault(x => x.Tentaikhoan == tk.Tentaikhoan && x.Matkhau == tk.Matkhau);
            Session["Use"] = check;
            if (check != null)
            {
                ModelState.AddModelError("", "Dang nhap thanh cong");
                return RedirectToAction("Index", "home");

            }
            else
            {
                ModelState.AddModelError("", "Dang nhap that bai");

            }
            return View("Index", tk);
        }
        public ActionResult DangXuat()
        {
            Session["Use"] = null;
            return RedirectToAction("Index", "Home");

        }
    }
}