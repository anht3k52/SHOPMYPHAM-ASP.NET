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
    public class chitietdonsController : Controller
    {
        private shopchangagoidemEntities1 db = new shopchangagoidemEntities1();

        // GET: admin/chitietdons
        public ActionResult Index()
        {
            var chitietdons = db.chitietdons.Include(c => c.donhang).Include(c => c.Sanpham);
            return View(chitietdons.ToList());
        }

        // GET: admin/chitietdons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietdon chitietdon = db.chitietdons.Find(id);
            if (chitietdon == null)
            {
                return HttpNotFound();
            }
            return View(chitietdon);
        }

        // GET: admin/chitietdons/Create
        public ActionResult Create()
        {
            ViewBag.Madonhang = new SelectList(db.donhangs, "Madonhang", "Tentaikhoan");
            ViewBag.Masanpham = new SelectList(db.Sanphams, "Masanpham", "Maloaisanpham");
            return View();
        }

        // POST: admin/chitietdons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Madonhang,soluong,thanhtien,Masanpham")] chitietdon chitietdon)
        {
            if (ModelState.IsValid)
            {
                db.chitietdons.Add(chitietdon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Madonhang = new SelectList(db.donhangs, "Madonhang", "Tentaikhoan", chitietdon.Madonhang);
            ViewBag.Masanpham = new SelectList(db.Sanphams, "Masanpham", "Maloaisanpham", chitietdon.Masanpham);
            return View(chitietdon);
        }

        // GET: admin/chitietdons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietdon chitietdon = db.chitietdons.Find(id);
            if (chitietdon == null)
            {
                return HttpNotFound();
            }
            ViewBag.Madonhang = new SelectList(db.donhangs, "Madonhang", "Tentaikhoan", chitietdon.Madonhang);
            ViewBag.Masanpham = new SelectList(db.Sanphams, "Masanpham", "Maloaisanpham", chitietdon.Masanpham);
            return View(chitietdon);
        }

        // POST: admin/chitietdons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Madonhang,soluong,thanhtien,Masanpham")] chitietdon chitietdon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietdon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Madonhang = new SelectList(db.donhangs, "Madonhang", "Tentaikhoan", chitietdon.Madonhang);
            ViewBag.Masanpham = new SelectList(db.Sanphams, "Masanpham", "Maloaisanpham", chitietdon.Masanpham);
            return View(chitietdon);
        }

        // GET: admin/chitietdons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietdon chitietdon = db.chitietdons.Find(id);
            if (chitietdon == null)
            {
                return HttpNotFound();
            }
            return View(chitietdon);
        }

        // POST: admin/chitietdons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chitietdon chitietdon = db.chitietdons.Find(id);
            db.chitietdons.Remove(chitietdon);
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
