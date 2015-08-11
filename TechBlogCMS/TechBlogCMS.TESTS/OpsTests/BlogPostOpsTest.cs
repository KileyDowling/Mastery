using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechBlogCMS.BLL;
using TechBlogCMS.DATA;
using TechBlogCMS.Models;

namespace TechBlogCMS.TESTS.OpsTests
{
    [TestClass]
    public class BlogPostOpsTest
    {
        [TestMethod]
        public void GetAllBlogPostsMockTest()
        {
            var ops = OperationsFactory.CreateBlogPostOps();
            var list = ops.GetAllBlogPosts();
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void GetAllBlogPostsDbTest()
        {
            var ops = OperationsFactory.CreateBlogPostOps();
            var list = ops.GetAllBlogPosts();
            Assert.AreEqual(1,list.Count);
        }

        [TestMethod]
        public void SaveBlogPostDbTest()
        {
            var ops = OperationsFactory.CreateBlogPostOps();

            BlogPost blog = new BlogPost()
            {
                DateOfPost = DateTime.Now,
                PostContent = "<p>Hello Lovely</p>",
                PostTitle = "Blog One",
                Status = new Status() { StatusID = 1 }

            };

            ops.SaveBlogPost(blog);
            var list = ops.GetAllBlogPosts();
            Assert.AreEqual(1,list.Count);

        }

        [TestMethod]
        public void SaveBlogPostDbNullDateTest()
        {
            var ops = OperationsFactory.CreateBlogPostOps();

            BlogPost blog = new BlogPost()
            {
                PostContent = "<p>Hello Lovely</p>",
                PostTitle = "Blog One",
                Status = new Status() { StatusID = 1 }

            };

            ops.SaveBlogPost(blog);

            var list = ops.GetAllBlogPosts();
            Assert.AreEqual(2, list.Count);

        }
    }

    }
