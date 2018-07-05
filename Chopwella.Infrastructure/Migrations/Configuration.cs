namespace Chopwella.Infrastructure.Migrations
{
    using Chopwella.Core;
    using Chopwella.Infrastructure.Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using static Chopwella.Infrastructure.Identity.IdentityModel;

    internal sealed class Configuration : DbMigrationsConfiguration<Chopwella.Infrastructure.ChopwellaDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Chopwella.Infrastructure.ChopwellaDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var cats = DummyData.GetCategories();
            var vendors = DummyData.GetVendors();
            var staff = DummyData.GetStaff();
            var visitors = DummyData.GetVisitors();
            var checkIns = DummyData.GetCheckIns();

            context.Set<Category>().AddRange(cats);
            context.Set<Vendor>().AddRange(vendors);
            context.Set<Staff>().AddRange(staff);
            context.Set<Visitor>().AddRange(visitors);
            context.Set<CheckIn>().AddRange(checkIns);


            string[] roles = new string[2] { "ADMIN", "VENDOR" };
            var roleStore = new RoleStore<AppRole, int, AppUserRole>(new ChopwellaDBContext());
            var roleManager = new RoleManager<AppRole, int>(roleStore);

            Array.ForEach(roles, r =>
            {
                if (roleManager.RoleExists(r))
                    return;

                roleManager.Create(new AppRole() { Name = r });
            });


            string username = "admin@cyberspace.com";
            string password = "admin";
            string role = "ADMIN";

            //IUserStore<Contact> contactStore = new UserStore<Contact>(new AcademyDbContext());
            //UserManager<Contact, string> userMgr = new UserManager<Contact, string>(contactStore);
            var userMgr = AuthStartupManager.UserManagerFactory.Invoke();


            if (userMgr.FindByName(username) != null)
                return;


            var user = new AppUser() { UserName = username, Email = username};
            var result = userMgr.Create(user, password);

            if (!roleManager.RoleExists(role))
            {
                var irole = new AppRole() { Name = role };
                roleManager.Create(irole);
            }

            if (!userMgr.IsInRole(user.Id, role))
            {
                userMgr.AddToRole(user.Id, role);
            }
        }
    }
}
