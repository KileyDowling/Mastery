using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechBlogCMS.BLL;
using TechBlogCMS.UI.Models;

namespace TechBlogCMS.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var ops = OperationsFactory.CreateBlogPostOps();
            var statusOps = OperationsFactory.CreateStatusOps();
            var categoryOps = OperationsFactory.CreateCategoryOps();
            BlogPostAllVM postsVM = new BlogPostAllVM()
            {
                BlogPosts = ops.GetAllBlogPosts().OrderByDescending(x=>x.DateOfPost).Take(5).ToList(),
                Statuses = statusOps.ListAllStatuses(),
                Categories = categoryOps.ListAllCategories()

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