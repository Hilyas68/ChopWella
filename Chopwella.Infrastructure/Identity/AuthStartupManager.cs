using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chopwella.Infrastructure.Identity.IdentityModel;

namespace Chopwella.Infrastructure.Identity
{
    public class AuthStartupManager
    {
        public static Func<RoleManager<AppRole, int>> RoleManagerFactory { get; private set; } = CreateRole;
        public static Func<UserManager<AppUser, int>> UserManagerFactory { get; private set; } = CreateUser;
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
