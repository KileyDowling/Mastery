using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechBlogCMS.DATA;
using TechBlogCMS.DATA.Mocks;
using TechBlogCMS.Models;
using TechblogCMS.MODELS;

namespace TechBlogCMS.TESTS
{
    [TestClass]
    public class CommentRepoTest
    {
        [TestMethod]
        public void GetAllCommentsByBlogPostIDMockTest()
        {
            var repo = new CommentMock();
            var commentsByID = repo.GetAllCommentsByPostID(1);
            Assert.AreEqual(3, commentsByID.Count);
            Assert.AreEqual("This is our second comment", commentsByID.FirstOrDefault(m => m.CommentContent == "This is our second comment").CommentContent);
            Assert.AreEqual("This is our first comment", commentsByID.FirstOrDefault(m => m.CommentID == 1).CommentContent);

        }

        [TestMethod]
        public void CreateCommentTest()
        {
            var repo = new CommentRepo();
            var comment = new Comment()
            {
                BlogPostID = 1,
                CommentContent = "This is a comment test",
                Status = new Status() { StatusID = 1 },
                User = new User(),
                Nickname = "Jake"
                
            };
            repo.CreateComment(comment);

            var list = repo.GetAllCommentsByPostID(1);
            Assert.AreEqual(1, list.Count);
        }
    }
}
