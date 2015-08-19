using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechblogCMS.MODELS;
using TechBlogCMS.DATA;
using TechBlogCMS.DATA.Mocks;
using TechBlogCMS.Models;

namespace TechBlogCMS.TESTS.RepoTests
{
    [TestClass]
    public class StaticPageRepoTest
    {
        [TestMethod]
        public void GetAllStaticPagesMockTest()
        {
            var repo = new StaticPageMock();
            List<StaticPage> staticPages = repo.GetAllStaticPages();
            var page = staticPages.FirstOrDefault(m => m.StaticPageID == 1);
            Assert.AreEqual("Static Page Number 1", page.StaticPageTitle);
            Assert.AreEqual(3, staticPages.Count);
        }

        [TestMethod]
        public void SaveStaticPageDBTest()
        {
            var repo = new StaticPageRepo();
            StaticPage staticPage = new StaticPage()
            {
                User = new User()
                {
                    UserId = "f319beb5-8a14-40c1-9cb5-0d6c92571ae4"
                },
                StaticPageContent = "<p>Do not do things</p>",
                StaticPageTitle = "Static Page Number 1",
                Status = new Status() { StatusID = 1 },
                DateOfPageCreation = DateTime.Now

            };
            repo.SaveStaticPage(staticPage);
            var list = repo.GetAllStaticPages();
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Static Page Number 1", list.FirstOrDefault(x => x.StaticPageID == 1).StaticPageTitle);
        }
    }
}
