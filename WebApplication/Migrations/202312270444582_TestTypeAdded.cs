namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestTypeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "Type");
        }
    }
}
