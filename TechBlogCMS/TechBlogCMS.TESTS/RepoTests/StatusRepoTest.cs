using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechBlogCMS.DATA;
using TechBlogCMS.DATA.Mocks;
using TechBlogCMS.Models;

namespace TechBlogCMS.TESTS
{
    [TestClass]
    public class StatusRepoTest
    {
        [TestMethod]
        public void ListAllStatusesDBTest()
        {
            var repo = new StatusRepo();
            List<Status> statuses  = repo.GetAllStatuses();
            var expected = 4;
            Assert.AreEqual(expected,statuses.Count);
        }
    }
}
