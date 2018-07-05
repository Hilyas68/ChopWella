using Chopwella.Core;
using Chopwella.ServiceInterface;
using System.Linq;
using System.Web.Mvc;

namespace Chopwella.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IServices<Category> catservice;
        private readonly IServices<Staff> staffservice;
        private readonly IServices<Vendor> vendorservice;

        public AdminController(IServices<Category> catservice, IServices<Staff> staffservice, IServices<Vendor> vendorservice)
        {
            this.catservice = catservice;
            this.staffservice = staffservice;
            this.vendorservice = vendorservice;
        }
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.StaffCount = staffservice.GetAll().Count();
            ViewBag.CatCount = catservice.GetAll().Count();
            ViewBag.VenCount = vendorservice.GetAll().Count();
            return View();
        }
        public ActionResult Staff()
        {
            ViewBag.Categories = catservice.GetAll();
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