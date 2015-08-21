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
    [Authorize(Roles = "Administrator")]
    public class ContentManagerController : Controller
    {
        public ActionResult Index()
        {
            var model = new List<BlogPost>();
            var ops = OperationsFactory.CreateBlogPostOps();
            model = ops.GetAllBlogPosts();

            return View(model);
        }
        // GET: BlogPost


        // GET: BlogPost/Details/5
        public ActionResult Details(int id)
        {
            var ops = OperationsFactory.CreateBlogPostOps();
            var blog = ops.GetBlogPostById(id);
            return View(blog);
        }

        // GET: BlogPost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPost/Create
        [HttpPost]
        public ActionResult Create(BlogPost blog)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogPost/Edit/5
        [Authorize(Roles = "Administrator, Contributor")]
        public ActionResult Edit(int id)
        {
            var blogOps = OperationsFactory.CreateBlogPostOps();
            
            var categoryOps = OperationsFactory.CreateCategoryOps();
            var hashOps = OperationsFactory.CreateHashtagOps();
            var statusOps = OperationsFactory.CreateStatusOps();
            var categoryList = categoryOps.ListAllCategories();
            var hastagList = hashOps.ListAllHashtags();
            var statusList = statusOps.ListAllStatuses();

            var model = new EditPostVM();
            {

                model.EditPost = blogOps.GetBlogPostById(id);

                //SelectedCategoryIds = new List<int>()

            };
            model.GenerateHashtagsList(hastagList);
            model.GenerateCategoriesList(categoryList);
            model.GenerateStatusList(statusList);
            model.HtmlContent = model.EditPost.PostContent;

            return View(model);
            
        }

        // POST: BlogPost/Edit/5

        [HttpPost]
        [Authorize(Roles = "Administrator, Contributor")]
        public ActionResult Edit(int id, EditPostVM model)
        {
            try
            {
                var blogPost = new BlogPost();
                
                blogPost = model.EditPost;
                blogPost.BlogPostID = id;
                blogPost.PostContent = model.HtmlContent;
                if (model.EditPost.Status == null)
                {
                    blogPost.Status = new Status()
                    {
                        StatusID = 1

                    };
                }
                else
                {
                    blogPost.Status.StatusID = model.EditPost.Status.StatusID;
                }
                var ops = OperationsFactory.CreateBlogPostOps();
                var categoryOps = OperationsFactory.CreateCategoryOps();
                ops.SaveBlogPost(blogPost);
                categoryOps.SaveBlogPostCategory(model.SelectedCategoryIds, blogPost);

                return RedirectToAction("Index", "ContentManager");
            }
            catch
            {
                return RedirectToAction("Index", "ContentManager");
            }
        }

        //GET: BlogPost/Delete/5
        public ActionResult Delete()
        {
            return RedirectToAction("Index", "ContentManager");
        }

        // POST: BlogPost/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var ops = OperationsFactory.CreateBlogPostOps();
                ops.DeleteBlogPost(id);

                return RedirectToAction("Index", "ContentManager");
            }
            catch
            {
                return RedirectToAction("Index", "ContentManager");
            }
        }

        //GET: Static Page
        public ActionResult CreateStaticPages()
        {
            StaticPageVM model = new StaticPageVM()
            {
                NewPage = new StaticPage()
                {
                    Status = new Status(),
                    User = new User()
                }

            };
            return View(model);
        }


        [HttpPost]
        public ActionResult CreateStaticPages(StaticPageVM model)
        {
            var staticPage = new StaticPage();

            staticPage = model.NewPage;
            staticPage.StaticPageContent = model.HtmlContent;
            if (model.NewPage.Status == null)
            {
                staticPage.Status = new Status()
                {
                    StatusID = 1

                };
            }
            else
            {
                staticPage.Status.StatusID = model.NewPage.Status.StatusID;
            }
            var ops = OperationsFactory.CreateStaticPageOps();

            ops.SaveStaticPage(staticPage);



            return RedirectToAction("Index", "Home");
        }

        //Display Static Page Links in Nav Bar
        [AllowAnonymous]
        public PartialViewResult StaticPagePartial()
        {
            var ops = OperationsFactory.CreateStaticPageOps();

            return PartialView("_StaticPagePartial", ops.GetAllStaticPages());
        }

        [AllowAnonymous]
        public ActionResult ReturnStaticPage(string id)
        {

            var ops = OperationsFactory.CreateStaticPageOps();
            var model = ops.GetStaticPageByTitle(id);
            return View(model);
        }
    }
}
