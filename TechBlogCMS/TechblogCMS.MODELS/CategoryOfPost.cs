using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogCMS.Models
{
    public class CategoryOfPost
    {
        public int CategoryID { get; set; }
        public string CategoryType { get; set; }
        public string CategoryDescription { get; set; }
    }
}
