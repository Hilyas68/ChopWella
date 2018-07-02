using Chopwella.Core;
using Chopwella.Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Chopwella.Infrastructure
{

    public class ChopwellaDBContext : IdentityDbContext<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public ChopwellaDBContext() : base("ChopWellaDB")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
    }
}
