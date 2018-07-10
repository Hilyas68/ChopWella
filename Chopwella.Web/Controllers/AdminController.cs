using Chopwella.Core;
using Chopwella.Infrastructure;
using Chopwella.ServiceInterface;
using Chopwella.Web.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Chopwella.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IServices<Category> catservice;
        private readonly IServices<Staff> staffservice;
        private readonly IServices<Vendor> vendorservice;
        private readonly IUserRepo userRepo;
        public AdminController(IServices<Category> catservice, IServices<Staff> staffservice, IServices<Vendor> vendorservice, IUserRepo userRepo)
        {
            this.catservice = catservice;
            this.staffservice = staffservice;
            this.vendorservice = vendorservice;
            this.userRepo = userRepo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.StaffCount = staffservice.GetAll().Count();
            ViewBag.CatCount = catservice.GetAll().Count();
            //ViewBag.VenCount = vendorservice.GetAll().Count();
            ViewBag.AdminCount = userRepo.GetUsersByRoles(1).Count();
            ViewBag.VenCount = userRepo.GetUsersByRoles(2).Count();
            var Create = userRepo.GetRoles;
            var model = new UserViewModel {
                Roles = Create
            };
            return View(model);
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