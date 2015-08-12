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
        public string UserName { get; set; }
        public int BlogPostID { get; set; }
        public List<SelectListItem> Statuses { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfPost { get; set; }


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