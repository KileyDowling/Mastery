using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogPost/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BlogPost blog)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
            var model= ops.GetStaticPageByTitle(id);
            return View(model);
        }
    }
}
