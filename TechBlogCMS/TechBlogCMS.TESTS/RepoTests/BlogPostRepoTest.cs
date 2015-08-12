using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechBlogCMS.DATA;
using TechBlogCMS.DATA.Mocks;
using TechBlogCMS.Models;

namespace TechBlogCMS.TESTS
{
    [TestClass]
    public class BlogPostRepoTest
    {
        [TestMethod]
        public void GetAllBlogPostsMockTest()
        {
            var repo = new BlogPostMock();
            List<BlogPost> blogPost = repo.GetAllBlogPosts();
            var blog = blogPost.FirstOrDefault(m => m.BlogPostID == 1);
            Assert.AreEqual("Blog Number 1", blog.PostTitle);
            Assert.AreEqual(3, blogPost.Count);

        }

        [TestMethod]
        public void GetAllBlogPostDBTest()
        {
            var repo = new BlogPostRepo();
            List<BlogPost> blogPost = repo.GetAllBlogPosts();
        }

        [TestMethod]
        public void SaveBlogPostDBTest()
        {
            var repo = new BlogPostRepo();
            BlogPost blog = new BlogPost()
            {
               PostContent = "<p>Hello Everyone</p>",
               PostTitle = "Blog More",
               Status = new Status(){StatusID = 1},
               //UserID = "f319beb5-8a14-40c1-9cb5-0d6c92571ae4",
               DateOfPost = DateTime.Now

            };
            repo.SaveBlogPost(blog);
            var list = repo.GetAllBlogPosts();
            Assert.AreEqual(6,list.Count);
            Assert.AreEqual("Blog One", list.FirstOrDefault(x=>x.BlogPostID == 1).PostTitle);
        }
    }
}
