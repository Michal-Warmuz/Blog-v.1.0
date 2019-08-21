namespace Blog.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        DateOfAddition = c.DateTime(nullable: false),
                        ShortContent = c.String(),
                    })
                .PrimaryKey(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Posts");
        }
    }
}
