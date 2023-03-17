using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnangcao1.Models;

namespace webnangcao1.Controllers
{
    public class layoutController : Controller
    {
        // GET: layout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult danhsachsanpham(string Type)
        {
            shopchangagoidemEntities1 db = new shopchangagoidemEntities1();
            List<Sanpham> lis = new List<Sanpham>();
            var lisr = db.Sanphams.Where(n => n.thuoctinh == Type).ToList();
            if (lisr != null)
            {
                lis = db.Sanphams.OrderBy(x => x.Masanpham).Where(x => x.thuoctinh == Type).Take(8).ToList();

            }
            else if(lisr != null)
            {
                lis = db.Sanphams.OrderByDescending(x => x.Masanpham).Where(x => x.thuoctinh == Type).Take(8).ToList();
            }
            ViewBag.Type = Type;
            return PartialView(lis);
         }
        public ActionResult sanphama()
        {
            shopchangagoidemEntities1 db = new shopchangagoidemEntities1();
            var lis = db.Sanphams.Where(n => n.Tinhtrang == 1 ).ToList();
            return PartialView(lis);
        }
    }

}