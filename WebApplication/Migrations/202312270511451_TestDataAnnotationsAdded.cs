namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestDataAnnotationsAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tests", "Title", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Tests", "Author", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Tests", "Description", c => c.String(nullable: false, maxLength: 7));
            AlterColumn("dbo.Tests", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tests", "Type", c => c.String());
            AlterColumn("dbo.Tests", "Description", c => c.String());
            AlterColumn("dbo.Tests", "Author", c => c.String());
            AlterColumn("dbo.Tests", "Title", c => c.String());
        }
    }
}
