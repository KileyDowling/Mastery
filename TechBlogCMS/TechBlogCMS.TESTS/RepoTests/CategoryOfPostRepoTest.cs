using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechBlogCMS.DATA;
using TechBlogCMS.DATA.Mocks;
using TechBlogCMS.Models;

namespace TechBlogCMS.TESTS
{
    [TestClass]
    public class CategoryOfPostRepoTest
    {
        [TestMethod]
        public void ListAllCategoriesMock()
        {
            var repo = new CategoryMock();
            var categoryList =  repo.ListAllCategories();
            Assert.AreEqual(3,categoryList.Count);
        }


        [TestMethod]
        public void CreateNewCategoryDb()
        {
            var repo = new CategoryOfPostsRepo();
            var category = new CategoryOfPost()
            {
                CategoryType = "Technology Trends",
                CategoryDescription = "Trends in tech"
            };
            repo.CreateCategory(category);

            var list = repo.ListAllCategories();
            Assert.AreEqual(1,list.Count);
        }

        [TestMethod]
        public void ListAllBlogsInCategoryByCategoryIdDbTest()
        {
            var repo = new BlogPostRepo();
            var list = repo.ListAllBlogsInCategoryByCategoryId(2);
            var blogPost = list.FirstOrDefault(x => x.BlogPostID == 4);
            Assert.AreEqual(1,list.Count);
            Assert.AreEqual("ASP.NET MVC5", blogPost.PostTitle);

        }
    }
}
