namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Questionary : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questionaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        QuestionType = c.String(),
                        AnsweredCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Questionaries");
        }
    }
}
