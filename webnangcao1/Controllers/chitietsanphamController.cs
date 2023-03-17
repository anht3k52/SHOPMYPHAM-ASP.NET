using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnangcao1.Models;

namespace webnangcao1.Controllers
{
    public class chitietsanphamController : Controller
    {
        // GET: chitietsanpham
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult xemchitiet(string masanpham )
        {
            quanlyshopEntities db = new quanlyshopEntities();
            var chitiet = db.Sanphams.Where(n => n.Masanpham == masanpham).FirstOrDefault();
            return View(chitiet);
        }

    }
}