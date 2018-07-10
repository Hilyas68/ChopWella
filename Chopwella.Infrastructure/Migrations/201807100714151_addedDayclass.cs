namespace Chopwella.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDayclass : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CheckIns", newName: "Days");
            DropIndex("dbo.Days", new[] { "StaffId" });
            DropIndex("dbo.Days", new[] { "VendorId" });
            AddColumn("dbo.Days", "Monday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Days", "Tuesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Days", "Wednesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Days", "Thursday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Days", "Friday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Days", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Days", "StaffId", c => c.Int());
            AlterColumn("dbo.Days", "IsChecked", c => c.Boolean());
            AlterColumn("dbo.Days", "Date", c => c.DateTime());
            AlterColumn("dbo.Days", "VendorId", c => c.Int());
            CreateIndex("dbo.Days", "StaffId");
            CreateIndex("dbo.Days", "VendorId");
            DropColumn("dbo.Days", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Days", "Name", c => c.String());
            DropIndex("dbo.Days", new[] { "VendorId" });
            DropIndex("dbo.Days", new[] { "StaffId" });
            AlterColumn("dbo.Days", "VendorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Days", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Days", "IsChecked", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Days", "StaffId", c => c.Int(nullable: false));
            DropColumn("dbo.Days", "Discriminator");
            DropColumn("dbo.Days", "Friday");
            DropColumn("dbo.Days", "Thursday");
            DropColumn("dbo.Days", "Wednesday");
            DropColumn("dbo.Days", "Tuesday");
            DropColumn("dbo.Days", "Monday");
            CreateIndex("dbo.Days", "VendorId");
            CreateIndex("dbo.Days", "StaffId");
            RenameTable(name: "dbo.Days", newName: "CheckIns");
        }
    }
}
