namespace Chopwella.Infrastructure.Migrations
{
    using Chopwella.Core;
    using System.Data.Entity.Migrations;

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

            DummyData.CreateFirstAdmin();
        }
    }
}



