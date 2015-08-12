using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechBlogCMS.Models;

namespace TechBlogCMS.UI.Models
{
    public class DraftPostVM
    {
        [AllowHtml]
        public string HtmlContent { get; set; }
        public BlogPost NewPost { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Statuses { get; set; }
        public List<SelectListItem> Hashtags { get; set; }
        public List<int> SelectedCategoryIds { get; set; }
        public List<Hashtag> SelectedHashtags { get; set; }

        public void GenerateCategoriesList(List<CategoryOfPost> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var c in categories)
            {
                Categories.Add(new SelectListItem() { Text = c.CategoryType, Value = c.CategoryID.ToString() });

            }
        }

        public void GenerateStatusList(List<Status> statuses)
        {
            Statuses = new List<SelectListItem>();

            foreach (var s in statuses)
            {
                Statuses.Add(new SelectListItem() { Text = s.StatusType, Value = s.StatusID.ToString() });

            }
        }


        public void GenerateHashtagsList(List<Hashtag> hashtags)
        {
            Hashtags = new List<SelectListItem>();

            foreach (var h in hashtags)
            {
                Hashtags.Add(new SelectListItem() { Text = h.HashtagType, Value = h.HashtagID.ToString() });

            }
        }
    }
}