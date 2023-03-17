using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using webnangcao1.Models;

namespace webnangcao1.Areas.admin
{
    public class loginController : Controller
    {
        // GET: admin/login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(taikhoan tk)
        {
            quanlyshopEntities db = new quanlyshopEntities();
            taikhoan check = db.taikhoans.FirstOrDefault(x => x.Tentaikhoan == tk.Tentaikhoan && x.Matkhau == tk.Matkhau && x.quyen == "admin");

            if (check != null)
            {
                ModelState.AddModelError("", "Dang nhap thanh cong");

                FormsAuthentication.SetAuthCookie(tk.Tentaikhoan, false);

                return RedirectToAction("Index", "home");
             
            }
            else
            {
                ModelState.AddModelError("", "Dang nhap that bai");
               
            }
            return View("Index", tk);
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}