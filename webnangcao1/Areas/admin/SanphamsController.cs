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
    public class SanphamsController : Controller
    {
        private quanlyshopEntities db = new quanlyshopEntities();

        // GET: admin/Sanphams
        public ActionResult Index()
        {
            var sanphams = db.Sanphams.Include(s => s.Loaisanpham);
            return View(sanphams.ToList());
        }

        // GET: admin/Sanphams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // GET: admin/Sanphams/Create
        public ActionResult Create()
        {
            ViewBag.Maloaisanpham = new SelectList(db.Loaisanphams, "Maloaisanpham", "Tenloaisanpham");
            return View();
        }

        // POST: admin/Sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masanpham,Maloaisanpham,Tensanpham,Thongtin,Ngay,Hinhchinh,Hinh1,Hinh2,Hinh3,Hinh4,Gia,Tinhtrang,thuoctinh")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                var fileimg = Request.Files["fileimg"];
                if (fileimg!=null && fileimg.ContentLength > 0)
                {
                    string[] f_name = fileimg.FileName.Split('.');
                    string file_name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + f_name[f_name.Length - 1];
                    string path = Server.MapPath("~/ss/admin/img/" + file_name);
                    fileimg.SaveAs(path);

                    sanpham.Hinhchinh = "/ss/admin/img/" + file_name; 
                }
                var fileimgg = Request.Files["fileimgg"];
                if (fileimgg != null && fileimgg.ContentLength > 0)
                {
                    string[] f_name = fileimgg.FileName.Split('.');
                    string file_name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + f_name[f_name.Length - 1];
                    string path = Server.MapPath("~/ss/admin/img/" + file_name);
                    fileimgg.SaveAs(path);

                    sanpham.Hinh1 = "/ss/admin/img/" + file_name;
                }
                var fileimggg = Request.Files["fileimggg"];
                if (fileimggg != null && fileimggg.ContentLength > 0)
                {
                    string[] f_name = fileimggg.FileName.Split('.');
                    string file_name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + f_name[f_name.Length - 1];
                    string path = Server.MapPath("~/ss/admin/img/" + file_name);
                    fileimggg.SaveAs(path);

                    sanpham.Hinh2 = "/ss/admin/img/" + file_name;
                }
                var fileimgggg = Request.Files["fileimgggg"];
                if (fileimgggg != null && fileimgggg.ContentLength > 0)
                {
                    string[] f_name = fileimgggg.FileName.Split('.');
                    string file_name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + f_name[f_name.Length - 1];
                    string path = Server.MapPath("~/ss/admin/img/" + file_name);
                    fileimgggg.SaveAs(path);

                    sanpham.Hinh3 = "/ss/admin/img/" + file_name;
                }
                var fileimggggg = Request.Files["fileimggggg"];
                if (fileimggggg != null && fileimggggg.ContentLength > 0)
                {
                    string[] f_name = fileimggggg.FileName.Split('.');
                    string file_name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + f_name[f_name.Length - 1];
                    string path = Server.MapPath("~/ss/admin/img/" + file_name);
                    fileimggggg.SaveAs(path);

                    sanpham.Hinh4 = "/ss/admin/img/" + file_name;
                }
                db.Sanphams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");

            }


            ViewBag.Maloaisanpham = new SelectList(db.Loaisanphams, "Maloaisanpham", "Tenloaisanpham", sanpham.Maloaisanpham);
            return View(sanpham);
        }

        // GET: admin/Sanphams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.Maloaisanpham = new SelectList(db.Loaisanphams, "Maloaisanpham", "Tenloaisanpham", sanpham.Maloaisanpham);
            return View(sanpham);
        }

        // POST: admin/Sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Masanpham,Maloaisanpham,Tensanpham,Thongtin,Ngay,Hinhchinh,Hinh1,Hinh2,Hinh3,Hinh4,Gia,Tinhtrang,thuoctinh")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                var fileig = Request.Files["fileig"];
                if (fileig != null && fileig.ContentLength > 0)
                {
                    string[] f_name = fileig.FileName.Split('.');
                    string file_name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + f_name[f_name.Length - 1];
                    string path = Server.MapPath("~/ss/admin/img/" + file_name);
                    fileig.SaveAs(path);

                    sanpham.Hinhchinh = "/ss/admin/img/" + file_name;
                }
                var fileigg = Request.Files["fileigg"];
                if (fileigg != null && fileigg.ContentLength > 0)
                {
                    string[] f_name = fileigg.FileName.Split('.');
                    string file_name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + f_name[f_name.Length - 1];
                    string path = Server.MapPath("~/ss/admin/img/" + file_name);
                    fileigg.SaveAs(path);

                    sanpham.Hinh1 = "/ss/admin/img/" + file_name;
                }
                var fileiggg = Request.Files["fileiggg"];
                if (fileiggg != null && fileiggg.ContentLength > 0)
                {
                    string[] f_name = fileiggg.FileName.Split('.');
                    string file_name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + f_name[f_name.Length - 1];
                    string path = Server.MapPath("~/ss/admin/img/" + file_name);
                    fileiggg.SaveAs(path);

                    sanpham.Hinh2 = "/ss/admin/img/" + file_name;
                }
                var fileigggg = Request.Files["fileigggg"];
                if (fileigggg != null && fileigggg.ContentLength > 0)
                {
                    string[] f_name = fileigggg.FileName.Split('.');
                    string file_name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + f_name[f_name.Length - 1];
                    string path = Server.MapPath("~/ss/admin/img/" + file_name);
                    fileigggg.SaveAs(path);

                    sanpham.Hinh3 = "/ss/admin/img/" + file_name;
                }
                var fileiggggg = Request.Files["fileiggggg"];
                if (fileiggggg != null && fileiggggg.ContentLength > 0)
                {
                    string[] f_name = fileiggggg.FileName.Split('.');
                    string file_name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + f_name[f_name.Length - 1];
                    string path = Server.MapPath("~/ss/admin/img/" + file_name);
                    fileiggggg.SaveAs(path);

                    sanpham.Hinh4 = "/ss/admin/img/" + file_name;
                }
                db.Sanphams.Add(sanpham);
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Maloaisanpham = new SelectList(db.Loaisanphams, "Maloaisanpham", "Tenloaisanpham", sanpham.Maloaisanpham);
            return View(sanpham);
        }

        // GET: admin/Sanphams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // POST: admin/Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sanpham sanpham = db.Sanphams.Find(id);
            db.Sanphams.Remove(sanpham);
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
