using Chopwella.Core;
using Chopwella.ServiceInterface;
using System.Web.Mvc;

namespace Chopwella.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServices<Category> catservice;

        public HomeController(IServices<Category> catservice)
        {
            this.catservice = catservice;
        }
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Categories = catservice.GetAll();
            return View();
        }       
    }
}