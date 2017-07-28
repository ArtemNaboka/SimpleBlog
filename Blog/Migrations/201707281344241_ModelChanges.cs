namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "AuthorName", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Text", c => c.String());
            AlterColumn("dbo.Comments", "AuthorName", c => c.String());
            AlterColumn("dbo.Articles", "Text", c => c.String());
            AlterColumn("dbo.Articles", "Name", c => c.String());
        }
    }
}
