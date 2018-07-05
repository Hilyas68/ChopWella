namespace Chopwella.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Auth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Staffs", "StaffNum", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Staffs", "StaffNum", c => c.String(nullable: false));
        }
    }
}
