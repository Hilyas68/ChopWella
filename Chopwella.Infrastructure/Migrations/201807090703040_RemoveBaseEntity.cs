namespace Chopwella.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBaseEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CheckIns", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckIns", "Name", c => c.String());
        }
    }
}
