namespace Blog.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class improve : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false));
            DropColumn("dbo.Comments", "CommentToId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "CommentToId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false, maxLength: 1020));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Content", c => c.String());
        }
    }
}
