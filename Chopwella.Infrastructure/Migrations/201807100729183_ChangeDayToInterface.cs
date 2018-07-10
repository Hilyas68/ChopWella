namespace Chopwella.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDayToInterface : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Days", newName: "CheckIns");
            DropIndex("dbo.CheckIns", new[] { "StaffId" });
            DropIndex("dbo.CheckIns", new[] { "VendorId" });
            AddColumn("dbo.Staffs", "Monday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Staffs", "Tuesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Staffs", "Wednesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Staffs", "Thursday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Staffs", "Friday", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CheckIns", "StaffId", c => c.Int(nullable: false));
            AlterColumn("dbo.CheckIns", "IsChecked", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CheckIns", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CheckIns", "VendorId", c => c.Int(nullable: false));
            CreateIndex("dbo.CheckIns", "StaffId");
            CreateIndex("dbo.CheckIns", "VendorId");
            DropColumn("dbo.CheckIns", "Monday");
            DropColumn("dbo.CheckIns", "Tuesday");
            DropColumn("dbo.CheckIns", "Wednesday");
            DropColumn("dbo.CheckIns", "Thursday");
            DropColumn("dbo.CheckIns", "Friday");
            DropColumn("dbo.CheckIns", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckIns", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.CheckIns", "Friday", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckIns", "Thursday", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckIns", "Wednesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckIns", "Tuesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.CheckIns", "Monday", c => c.Boolean(nullable: false));
            DropIndex("dbo.CheckIns", new[] { "VendorId" });
            DropIndex("dbo.CheckIns", new[] { "StaffId" });
            AlterColumn("dbo.CheckIns", "VendorId", c => c.Int());
            AlterColumn("dbo.CheckIns", "Date", c => c.DateTime());
            AlterColumn("dbo.CheckIns", "IsChecked", c => c.Boolean());
            AlterColumn("dbo.CheckIns", "StaffId", c => c.Int());
            DropColumn("dbo.Staffs", "Friday");
            DropColumn("dbo.Staffs", "Thursday");
            DropColumn("dbo.Staffs", "Wednesday");
            DropColumn("dbo.Staffs", "Tuesday");
            DropColumn("dbo.Staffs", "Monday");
            CreateIndex("dbo.CheckIns", "VendorId");
            CreateIndex("dbo.CheckIns", "StaffId");
            RenameTable(name: "dbo.CheckIns", newName: "Days");
        }
    }
}
