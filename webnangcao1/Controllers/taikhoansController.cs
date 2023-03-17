using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webnangcao1.Models;

namespace webnangcao1.Controllers
{
    public class taikhoansController : Controller
    {
        private quanlyshopEntities db = new quanlyshopEntities();

        // GET: taikhoans
        public ActionResult Index()
        {
            return View("Index","Home");
     
        }

        // GET: taikhoans/Details/5
        // GET: taikhoans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: taikhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tentaikhoan,Matkhau,fullname,email,sdt")] taikhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                db.taikhoans.Add(taikhoan);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(taikhoan);
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
