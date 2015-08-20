using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechBlogCMS.Models;

namespace TechBlogCMS.UI.Models
{
    public class ApprovalVM
    {
        public List<BlogPost> ListOfPosts { get; set; }
        public List<BlogPost> ScheduledPosts { get; set; }
        public List<BlogPost> RejectedPostsList { get; set; }
        public List<BlogPost> DraftedPosts { get; set; }
        public List<Comment> CommentsToBeApproved { get; set; }
        public List<SelectListItem> Statuses { get; set; }
        public int BlogPostId { get; set; }
        public int StatusId { get; set; }

        public BlogPost SelectedBlogPost { get; set; }



        public void GenerateStatusList(List<Status> statuses)
        {
            Statuses = new List<SelectListItem>();

            foreach (var s in statuses)
            {
                Statuses.Add(new SelectListItem() { Text = s.StatusType, Value = s.StatusID.ToString() });

            }
        }
    }


}