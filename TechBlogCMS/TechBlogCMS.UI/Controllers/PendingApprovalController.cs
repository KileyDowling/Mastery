using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechBlogCMS.BLL;
using TechBlogCMS.UI.Models;

namespace TechBlogCMS.UI.Controllers
{
    public class PendingApprovalController : Controller
    {
        // GET: PendingApproval
        public ActionResult PendingApproval()
        {
            var model = new ApprovalVM();
            var statusOps = OperationsFactory.CreateStatusOps();
            var statusList = statusOps.ListAllStatuses();

            model.GenerateStatusList(statusList);
            
            return View(model);
        }
    }
}