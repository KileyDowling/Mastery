using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechBlogCMS.BLL;
using TechBlogCMS.Models;

namespace TechBlogCMS.UI.Controllers
{
    public class FilterBlogPostController : ApiController
    {
        List<BlogPost> Get()
        {
            var ops = OperationsFactory.CreateBlogPostOps();
            var list = ops.GetAllBlogPosts();
            return list;
        }


        List<BlogPost> Get(CategoryOfPost category)
        {
            var ops = OperationsFactory.CreateCategoryOps();
            var list = ops.ListAllBlogsInCategoryByCategoryId(category.CategoryID);
            return list;
        }

        List<BlogPost> Get(Hashtag hashtag)
        {
            var ops = OperationsFactory.CreateHashtagOps();

            return new List<BlogPost>();
          
        }
    }
}
