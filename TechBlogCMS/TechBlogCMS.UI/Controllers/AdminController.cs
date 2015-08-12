using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechBlogCMS.BLL;
using TechBlogCMS.UI.Models;

namespace TechBlogCMS.UI.Controllers
{
    public class AdminController : Controller
    {
         // GET: Admin
        [Authorize(Roles = "Administration")]
        public ActionResult Admin()
        {
            
            
            return View();
        }
    }
}