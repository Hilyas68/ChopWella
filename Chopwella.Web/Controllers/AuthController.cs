using Chopwella.Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Chopwella.Web.Controllers
{
    public class AuthController : Controller
    {

        private UserManager<AppUser, int> userMgr;
        private RoleManager<AppRole, int> roleMgr;
        public IAuthenticationManager Authmgr => this.HttpContext.GetOwinContext().Authentication;

        public AuthController()
        {
            userMgr = Startup.UserManagerFactory.Invoke();
            roleMgr = Startup.RoleManagerFactory.Invoke();
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
                var user = await userMgr.FindAsync(lvm.UserName, lvm.Password);
                if (user != null)
                {
                    ClaimsIdentity claimsIdentity = await userMgr.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    Authmgr.SignIn(claimsIdentity);

                    bool isAdmin = userMgr.IsInRole(user.Id, "Admin");

                    if (isAdmin)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
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