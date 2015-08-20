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
            var commentOps = OperationsFactory.CreateCommentOps();
            model.ListOfPosts = blogPostOps.GetAllBlogPosts().FindAll(x=>x.Status.StatusID == 1);
            model.RejectedPostsList = blogPostOps.GetAllBlogPosts().FindAll(x => x.Status.StatusID == 3);
            model.DraftedPosts = blogPostOps.GetAllBlogPosts().FindAll(x => x.Status.StatusID == 5);
            model.ScheduledPosts = blogPostOps.GetAllBlogPosts().FindAll(x => x.Status.StatusID == 6 || x.DateOfPost > DateTime.Today);
            model.CommentsToBeApproved = commentOps.GetAllComments().FindAll(x => x.Status.StatusID == 1);
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

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var ops = OperationsFactory.CreateBlogPostOps();
                ops.DeleteBlogPost(id);

                return RedirectToAction("PendingApproval", "PendingApproval");
            }
            catch
            {
                return RedirectToAction("PendingApproval","PendingApproval");
            }
        }

        [HttpPost]
        public ActionResult DeleteComment(int id)
        {
            try 
            {
                var ops = OperationsFactory.CreateCommentOps();
                ops.DeleteComment(id);
                return RedirectToAction("PendingApproval", "PendingApproval");
            }
            catch
            {
                return RedirectToAction("PendingApproval", "PendingApproval");
            }
        }

        [HttpPost]
        public ActionResult ApproveComment(int commentId)
        {
            var ops = OperationsFactory.CreateCommentOps();
            ops.ApproveComment(commentId, 2);

            return RedirectToAction("PendingApproval", "PendingApproval");


        }
    }
}