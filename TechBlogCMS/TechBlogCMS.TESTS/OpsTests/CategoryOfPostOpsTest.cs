using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechBlogCMS.BLL;
using TechBlogCMS.DATA;
using TechBlogCMS.Models;

namespace TechBlogCMS.TESTS.OpsTests
{
    [TestClass]
    public class CategoryOfPostOpsTest
    {
        [TestMethod]
        public void ListAllCategoriesDbTest()
        {
            var ops = OperationsFactory.CreateCategoryOps();
            var list = ops.ListAllCategories();
            Assert.AreEqual(0,list.Count);

        }

        [TestMethod]
        public void CreateCategoryDbEmptyTypeTest()
        {
            var ops = OperationsFactory.CreateCategoryOps();
            var category = new CategoryOfPost()
            {
                CategoryDescription = "Hello world"
            };
            ops.CreateCategory(category);
            var list = ops.ListAllCategories();
            Assert.AreEqual(1,list.Count);
        }

    }

}
