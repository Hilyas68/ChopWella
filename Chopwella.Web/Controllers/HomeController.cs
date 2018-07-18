using Chopwella.Core;
using Chopwella.ServiceInterface;
using System.Web.Mvc;

namespace Chopwella.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IServices<Category> catservice;
        private readonly IServices<Staff> staffservice;

        public HomeController(IServices<Category> catservice, IServices<Staff> staffservice)
        {
            this.catservice = catservice;
            this.staffservice = staffservice;
        }
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Categories = catservice.GetAll();
            ViewBag.Staff = staffservice.GetAll();
            return View();
        }       
    }
}