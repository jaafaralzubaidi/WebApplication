namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestDateTimeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "CreatedAt");
        }
    }
}
