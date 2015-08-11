using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace TechBlogCMS.Models
{
    public class BlogPost
    {
        public int BlogPostID { get; set; }
        public string UserID { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public Status Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfPost { get; set; }
    }
}
