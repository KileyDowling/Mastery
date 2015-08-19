using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogCMS.DATA;
using TechBlogCMS.DATA.Mocks;
using TechBlogCMS.Models;

namespace TechBlogCMS.BLL
{
    public class OperationsFactory
    {
        private static string mode = ConfigurationManager.AppSettings["Mode"];

        public static BlogPostOps CreateBlogPostOps()
        {
            if (mode == "Test")
                return new BlogPostOps(new BlogPostMock());
            else
            {
                return new BlogPostOps(new BlogPostRepo());
            }
        }

        public static StatusOps CreateStatusOps()
        {
            if (mode == "Test")
                return new StatusOps(new StatusMock());
            else
            {
                return new StatusOps(new StatusRepo());
            }
        }

        public static CommentOps CreateCommentOps()
        {
            if (mode == "Test")
                return new CommentOps(new CommentMock());
            else
            {
                return new CommentOps(new CommentRepo());
            }
        }

        public static CategoryOfPostOps CreateCategoryOps()
        {
            if (mode == "Test")
                return new CategoryOfPostOps(new CategoryMock());
            else
            {
                return new CategoryOfPostOps(new CategoryOfPostsRepo());
            }
        }

        public static HashtagOps CreateHashtagOps()
        {
            if (mode == "Test")
                return new HashtagOps(new HashtagMock());
            else
            {
                return new HashtagOps(new HashtagRepo());
            }
        }

        public static StaticPageOps CreateStaticPageOps()
        {
            if (mode == "Test")
                return new StaticPageOps(new StaticPageMock());
            else
            {
                return new StaticPageOps(new StaticPageRepo());
            }
        }
    }


}
