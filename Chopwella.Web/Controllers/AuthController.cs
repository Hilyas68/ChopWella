using Chopwella.Infrastructure;
using Chopwella.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Chopwella.Web.Controllers
{
    public class AuthController : Controller
    {

        private readonly IUserRepo _repo;
        public IAuthenticationManager Authmgr => this.HttpContext.GetOwinContext().Authentication;

        public AuthController(IUserRepo repo)
        {
            _repo = repo;
        }


        public ActionResult Logout()
        {
            var ctxt = this.Request.GetOwinContext();
            Authmgr.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return Redirect("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel lvm, string returnUrl)
        {
            if (this.ModelState.IsValid)
            {

                var user = await _repo.SignIn(lvm.UserName, lvm.Password);
                if (user != null)
                {
                    ClaimsIdentity claimsIdentity = await _repo.FindUserAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    Authmgr.SignIn(claimsIdentity);

                    bool isAdmin = _repo.IsInRole(user, "ADMIN");

                    if (isAdmin)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Vendor");
                    }

                }
                else
                {
                    this.ModelState.AddModelError("", "Username or password is invalid");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }
    }
}