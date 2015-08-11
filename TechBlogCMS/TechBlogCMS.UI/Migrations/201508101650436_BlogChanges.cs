namespace TechBlogCMS.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogChanges : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.BlogPosts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        BlogPostID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        PostTitle = c.String(),
                        PostContent = c.String(),
                        StatusID = c.Int(nullable: false),
                        DateOfPost = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogPostID);
            
        }
    }
}
