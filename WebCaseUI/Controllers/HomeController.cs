using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCaseUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Case()
        {
            ViewBag.Message = "Your case page.";

            return View();
        }
        public ActionResult Update()
        {
            ViewBag.Message = "Your update page.";

            return View();
        }
    }
}