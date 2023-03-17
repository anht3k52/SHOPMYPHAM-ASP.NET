using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webnangcao1.Areas.admin
{
    public class homeController : Controller
    {
        [Authorize]
        // GET: admin/home
        public ActionResult Index()
        {
            return View();
        }
    }
}