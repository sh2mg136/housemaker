using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace themesite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            RedirectToAction("Wellcome");
            return View();
        }

        public ActionResult Wellcome()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}