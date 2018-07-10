namespace Chopwella.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mixedName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckIns", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckIns", "Name");
        }
    }
}
