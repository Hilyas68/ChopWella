using Chopwella.Core;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using static Chopwella.Infrastructure.Identity.IdentityModel;

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
        public DbSet<CheckIn> checkIns { get; set; }
    }
}
