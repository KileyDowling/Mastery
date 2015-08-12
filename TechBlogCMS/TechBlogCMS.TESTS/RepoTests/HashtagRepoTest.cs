using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechBlogCMS.BLL;
using TechBlogCMS.DATA.Mocks;
using TechBlogCMS.Models;

namespace TechBlogCMS.TESTS
{
    [TestClass]
    public class HashtagRepoTest
    {
        [TestMethod]
        public void ListAllHashtagsMockTest()
        {
            var repo = new HashtagMock();
            var hashTagList = repo.ListAllHashtags();
            Assert.AreEqual(3, hashTagList.Count);
            Assert.AreEqual("#computers", hashTagList.FirstOrDefault(m => m.HashtagType == "#computers").HashtagType);
        }

        [TestMethod]
        public void CreateNewHashtagDbTest()
        {
            var repo = OperationsFactory.CreateHashtagOps();
            var hashtag = new Hashtag()
            {
                HashtagType = "Trends",
            };
            repo.CreateHashtag(hashtag);
            var list = repo.ListAllHashtags();
            Assert.AreEqual(1,list.Count);
        }
        
    }
}
