namespace TechBlogCMS.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPost",
                c => new
                    {
                        BlogPostID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        BlogTitle = c.String(),
                        PostContent = c.String(),
                        StatusID = c.Int(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogPostID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlogPost");
        }
    }
}
