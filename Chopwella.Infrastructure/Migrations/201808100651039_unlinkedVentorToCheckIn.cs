namespace Chopwella.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unlinkedVentorToCheckIn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CheckIns", "VendorId", "dbo.Vendors");
            DropIndex("dbo.CheckIns", new[] { "VendorId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.CheckIns", "VendorId");
            AddForeignKey("dbo.CheckIns", "VendorId", "dbo.Vendors", "Id", cascadeDelete: true);
        }
    }
}
