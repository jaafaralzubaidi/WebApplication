namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestsUserIdAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "UserID");
        }
    }
}
