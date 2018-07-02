using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Chopwella.Infrastructure;
using Chopwella.Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartup(typeof(Chopwella.Web.Startup))]

namespace Chopwella.Web
{
    public class Startup
    {
        public static Func<RoleManager<AppRole, int>> RoleManagerFactory { get; private set; } = CreateRole;
        public static Func<UserManager<AppUser, int>> UserManagerFactory { get; private set; } = CreateUser;
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Auth/Login"),
                CookieName = "ChopWella"
            });


        }

        public static RoleManager<AppRole, int> CreateRole()
        {
            var dbContext = new ChopwellaDBContext();
            var rolestore = new RoleStore<AppRole, int, AppUserRole>(dbContext);
            var rolemanager = new RoleManager<AppRole, int>(rolestore);
            // allow alphanumeric characters in username
            return rolemanager;
        }

        public static UserManager<AppUser, int> CreateUser()
        {
            var dbContext = new ChopwellaDBContext();
            var store = new UserStore<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>(dbContext);
            var usermanager = new UserManager<AppUser, int>(store);
            // allow alphanumeric characters in username
            usermanager.UserValidator = new UserValidator<AppUser, int>(usermanager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false,
            };

            usermanager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 4,
                RequireDigit = false,
                RequireUppercase = false
            };

            return usermanager;
        }
    }
}
