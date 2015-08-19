using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechblogCMS.MODELS;
using TechBlogCMS.Models;

namespace TechBlogCMS.UI.Models
{
    public class StaticPageVM
    {
        [AllowHtml]
        public string HtmlContent { get; set; }
        public StaticPage NewPage { get; set; }
    }
}