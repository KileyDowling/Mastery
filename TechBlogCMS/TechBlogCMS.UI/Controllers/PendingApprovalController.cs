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
    public class PendingApprovalController : Controller
    {
        // GET: PendingApproval
        [Authorize(Roles = "Administrator")]
        public ActionResult PendingApproval()
        {
            var model = new ApprovalVM()
            {
                SelectedBlogPost = new BlogPost()
            };
            var blogPostOps = OperationsFactory.CreateBlogPostOps();
            var statusOps = OperationsFactory.CreateStatusOps();
            model.ListOfPosts = blogPostOps.GetAllBlogPosts().FindAll(x=>x.Status.StatusID == 1);
            model.RejectedPostsList = blogPostOps.GetAllBlogPosts().FindAll(x => x.Status.StatusID == 3);
            model.DraftedPosts = blogPostOps.GetAllBlogPosts().FindAll(x => x.Status.StatusID == 5);
            var statusList = statusOps.ListAllStatuses();

            model.GenerateStatusList(statusList);
            
            return View(model);
        }

        [HttpPost]
        public ActionResult PendingApproval(int blogPostId, int statusId)
        {
            var statusOps = OperationsFactory.CreateStatusOps();
            statusOps.UpdateStatus(blogPostId,statusId);

            return RedirectToAction("PendingApproval");
        }
    }
}