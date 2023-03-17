using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webnangcao1.Models;

namespace webnangcao1.Areas.admin
{
    public class donhangsController : Controller
    {
        private quanlyshopEntities db = new quanlyshopEntities();

        // GET: admin/donhangs
        public ActionResult Index()
        {
            var donhangs = db.donhangs.Include(d => d.taikhoan);
            return View(donhangs.ToList());
        }

        // GET: admin/donhangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donhang donhang = db.donhangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // GET: admin/donhangs/Create
        public ActionResult Create()
        {
            ViewBag.Tentaikhoan = new SelectList(db.taikhoans, "Tentaikhoan", "Matkhau");
            return View();
        }

        // POST: admin/donhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Madonhang,Tentaikhoan,dathanhtoan,tinhtrangdathang,ngaydat,ngaygiao")] donhang donhang)
        {
            if (ModelState.IsValid)
            {
                db.donhangs.Add(donhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tentaikhoan = new SelectList(db.taikhoans, "Tentaikhoan", "Matkhau", donhang.Tentaikhoan);
            return View(donhang);
        }

        // GET: admin/donhangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donhang donhang = db.donhangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tentaikhoan = new SelectList(db.taikhoans, "Tentaikhoan", "Matkhau", donhang.Tentaikhoan);
            return View(donhang);
        }

        // POST: admin/donhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Madonhang,Tentaikhoan,dathanhtoan,tinhtrangdathang,ngaydat,ngaygiao")] donhang donhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tentaikhoan = new SelectList(db.taikhoans, "Tentaikhoan", "Matkhau", donhang.Tentaikhoan);
            return View(donhang);
        }

        // GET: admin/donhangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donhang donhang = db.donhangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // POST: admin/donhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            donhang donhang = db.donhangs.Find(id);
            db.donhangs.Remove(donhang);
            db.SaveChanges();
            return RedirectToAction("Index");
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
