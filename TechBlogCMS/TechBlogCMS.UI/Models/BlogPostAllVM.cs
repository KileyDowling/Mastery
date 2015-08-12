using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using TechBlogCMS.Models;

namespace TechBlogCMS.UI.Models
{
    public class BlogPostAllVM
    {
        public List<BlogPost> BlogPosts { get; set; }
        public List<Status> Statuses { get; set; }
        public List<CategoryOfPost> Categories { get; set; }
        public List<CategoryOfPost> AllCategoriesForBlogPost { get; set; }

        
        //user -- user name
        //title
        //content
        //date of post -- 

    }
}