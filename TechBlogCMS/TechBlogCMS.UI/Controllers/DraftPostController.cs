using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Http.Validation.Validators;
using System.Web.Mvc;
using System.Web.Security;
using TechblogCMS.MODELS;
using TechBlogCMS.BLL;
using TechBlogCMS.Models;
using TechBlogCMS.UI.Models;

namespace TechBlogCMS.UI.Controllers
{
    public class DraftPostController : Controller
    {
        // GET: DraftPost
        [Authorize(Roles = "Administrator, Contributor")]
        public ActionResult Index()
        {

            DraftPostVM model = new DraftPostVM()
            {
                NewPost = new BlogPost()
                {
                    Status = new Status(),
                    User = new User()
                },

                SelectedCategoryIds = new  List<int>()

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
            categoryOps.SaveBlogPostCategory(model.SelectedCategoryIds,blogPost);


            return RedirectToAction("Index","Home");

        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(CategoryOfPost newCategory)
        {
            var ops = OperationsFactory.CreateCategoryOps();
            ops.CreateCategory(newCategory);

            return RedirectToAction("Index","DraftPost");
        }


        public ActionResult CreateHashtag()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateHashtag(Hashtag newHashtag)
        {
            var ops = OperationsFactory.CreateHashtagOps();
            ops.CreateHashtag(newHashtag);

            return RedirectToAction("Index", "DraftPost");
        }
    }
}