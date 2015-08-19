using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogCMS.Models;

namespace TechblogCMS.MODELS
{
    public class StaticPage
    {
        public int StaticPageID { get; set; }
        public User User { get; set; }
        public string StaticPageTitle { get; set; }
        public string StaticPageContent { get; set; }
        public Status Status { get; set; }
        public List<StaticPage> StaticPageList { get; set; }
            
            [DataType(DataType.Date)]
        public DateTime DateOfPageCreation { get; set; }

        public string GetUrlSlug()
        {
            return StaticPageTitle.Trim().Replace(" ", "_");
        }
    }
}
