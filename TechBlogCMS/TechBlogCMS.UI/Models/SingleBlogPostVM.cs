using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechBlogCMS.Models;

namespace TechBlogCMS.UI.Models
{
    public class SingleBlogPostVM
    {
        public BlogPost SelectedBlogPost { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment NewComment { get; set; }
    }
}