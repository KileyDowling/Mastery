using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechBlogCMS.BLL;
using TechBlogCMS.Models;
using TechBlogCMS.UI.Models;

namespace TechBlogCMS.UI.Controllers
{
    public class DraftPostController : Controller
    {
        // GET: DraftPost
        public ActionResult Index()
        {

            DraftPostVM model = new DraftPostVM()
            {
                NewPost = new BlogPost()
                {
                    Status = new Status()
                },

                SelectedCategory = new CategoryOfPost()

            };
            var categoryOps = OperationsFactory.CreateCategoryOps();
            var hashOps = OperationsFactory.CreateHashtagOps();
            var statusOps = OperationsFactory.CreateStatusOps();

            var categoryList = categoryOps.ListAllCategories();
            var hastagList = hashOps.ListAllHashtags();
           var statusList = statusOps.ListAllStatuses();
            model.GenerateHashtagsList(hastagList);
            model.GenerateCategoriesList(categoryList);
           model.GenerateStatusList(statusList);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(DraftPostVM model)
        {
            var blogPost = new BlogPost();

            blogPost = model.NewPost;
            blogPost.PostContent = model.HtmlContent;
            if (model.NewPost.Status == null)
            {
                blogPost.Status = new Status()
                {
                    StatusID = 1

                };
            }
            else
            {
                blogPost.Status.StatusID = model.NewPost.Status.StatusID;
            }
            var ops = OperationsFactory.CreateBlogPostOps();
            var categoryOps = OperationsFactory.CreateCategoryOps();
            ops.SaveBlogPost(blogPost);
            categoryOps.SaveBlogPostCategory(model.SelectedCategory.CategoryID,blogPost);


            return RedirectToAction("Index","Home");

        }
    }
}