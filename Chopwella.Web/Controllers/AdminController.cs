using Chopwella.Core;
using Chopwella.ServiceInterface;
using System.Web.Mvc;

namespace Chopwella.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IServices<Category> catservice;

        public AdminController(IServices<Category> catservice)
        {
            this.catservice = catservice;
        }
        // GET: Admin
        public ActionResult Index()
        {
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