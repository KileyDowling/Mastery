using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TechBlogCMS.Models;

namespace TechBlogCMS.UI.Models
{
    public class BlogPostAllVM
    {
        public List<BlogPost> BlogPosts { get; set; }
        public string SelectedCategoryName { get; set; }
        public string SelectedHashtagName{ get; set; }
        public int SelectedCategoryId { get; set; }
        public int SelectedHashtagId { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Hashtags { get; set; }

        public void GenerateCategoriesList(List<CategoryOfPost> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var c in categories)
            {
                Categories.Add(new SelectListItem() { Text = c.CategoryType, Value = c.CategoryID.ToString() });

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