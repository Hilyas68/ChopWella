using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Chopwella.Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using static Chopwella.Infrastructure.Identity.IdentityModel;

namespace Chopwella.Infrastructure
{
    public interface IUserRepo
    {
        IEnumerable<AppRole> GetRoles { get; }
        IEnumerable<AppUser> GetUsers { get; }
        Task<IdentityResult> CreateUser(string username, string email, string password, string role);
        Task<IdentityResult> RemoveUser(int userId);
        Task<AppUser> SignIn(string username, string password);
        Task<ClaimsIdentity> FindUserAsync(AppUser user, string authType);
        bool IsInRole(AppUser user, string role);
    }
}