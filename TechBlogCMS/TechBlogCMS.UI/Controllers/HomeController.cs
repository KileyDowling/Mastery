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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var ops = OperationsFactory.CreateBlogPostOps();
            BlogPostAllVM postsVM = new BlogPostAllVM()
            {
                BlogPosts = ops.GetAllBlogPosts().FindAll(x=>x.Status.StatusID == 2).FindAll(x=>x.DateOfPost <= DateTime.Today).OrderByDescending(x=>x.DateOfPost).Take(5).ToList(),
            };

            return View(postsVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}