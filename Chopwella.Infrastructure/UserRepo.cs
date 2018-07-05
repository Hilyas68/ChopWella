using Chopwella.DomainInterface;
using Chopwella.Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Chopwella.Infrastructure.Identity.IdentityModel;

namespace Chopwella.Infrastructure
{
    public class UserRepo : IUserRepo
    {
        private UserManager<AppUser, int> userMgr;
        private RoleManager<AppRole, int> roleMgr;

        public UserRepo()
        {
            userMgr = AuthStartupManager.UserManagerFactory.Invoke();
            roleMgr = AuthStartupManager.RoleManagerFactory.Invoke();
        }

        public IEnumerable<AppRole> GetRoles
        {
            get { return roleMgr.Roles.ToList(); }
        }

        public IEnumerable<AppUser> GetUsers
        {
            get { return userMgr.Users.ToList(); }
        }

        public async Task<IdentityResult> CreateUser(string username, string email, string password, string role)
        {
            var user = new AppUser
            {
                UserName = username,
                Email = email,
            };
            IdentityResult identity = await userMgr.CreateAsync(user, password);
            if (!roleMgr.RoleExists(role))
            {
                var irole = new AppRole() { Name = role };
                roleMgr.Create(irole);
            }
            if (!userMgr.IsInRole(user.Id, role))
            {
                userMgr.AddToRole(user.Id, role);
            }
            return identity;
        }

        public async Task<IdentityResult> RemoveUser(int userId)
        {
            AppUser user = userMgr.Users.SingleOrDefault(u => u.Id == userId);

            return await userMgr.DeleteAsync(user);
        }

        public async Task<AppUser> SignIn(string username, string password)
        {
            var user = await userMgr.FindAsync(username, password);
            return user;
        }
       
        public async Task<ClaimsIdentity> FindUserAsync(AppUser user, string authType)
        {
            return await userMgr.CreateIdentityAsync(user, authType);
        }

        public bool IsInRole(AppUser user, string role)
        {
            return userMgr.IsInRole(user.Id, role);
        }
    }
}
