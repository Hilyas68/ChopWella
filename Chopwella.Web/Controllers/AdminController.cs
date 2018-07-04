using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chopwella.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Staff()
        {
            return View();
        }
        public ActionResult Vendor()
        {
            return View();
        }
        public ActionResult Category()
        {
            return View();
        }
    }
}