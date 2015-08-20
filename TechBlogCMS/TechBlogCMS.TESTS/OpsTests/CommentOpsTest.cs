using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechBlogCMS.BLL;
using TechBlogCMS.Models;
using TechblogCMS.MODELS;

namespace TechBlogCMS.TESTS.OpsTests
{
    [TestClass]
    public class CommentOpsTest
    {
        [TestMethod]
        public void CreateCommentFailedDateTimeDBTest()
        {
            var ops = OperationsFactory.CreateCommentOps();
            var comment = new Comment()
            {
                BlogPostID = 1,
                CommentContent = "Lets test these thangs",
                Status = new Status() { StatusID = 1 },
                User = new User(),
                Nickname = "Kiley",
                DateOfComment = new DateTime(7/24/2015)
            };
            ops.CreateComment(comment);
            var commentList = ops.GetAllCommentsByBlogPostID(1);
            Assert.AreEqual(1, commentList.Count);
        }
    }
}
