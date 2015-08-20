using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS;

namespace TechBlogCMS.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int BlogPostID { get; set; }
        public string CommentContent { get; set; }
        public Status Status { get; set; }
        public User User { get; set; }
        public string Nickname { get; set; }
        public DateTime DateOfComment { get; set; }
    }
}
