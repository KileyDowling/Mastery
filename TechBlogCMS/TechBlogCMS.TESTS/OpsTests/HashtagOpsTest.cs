using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechBlogCMS.BLL;
using TechBlogCMS.Models;

namespace TechBlogCMS.TESTS
{
    [TestClass]
    public class HashtagOpsTest
    {
        [TestMethod]
        public void CreateNewCategoryEmptyTypeDbTest()
        {
            
            var ops = OperationsFactory.CreateHashtagOps();
            var hashtag = new Hashtag()
            {
            };
            ops.CreateHashtag(hashtag);
            var list = ops.ListAllHashtags();
            Assert.AreEqual(1,list.Count);
        
    }
    }
}
