using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechblogCMS.MODELS
{
    public class RejectedPosts
    {
        public int RejectionId { get; set; }
        public int BlogPostID { get; set; }
        public string RejectionReason { get; set; }
        public DateTime DateRejected { get; set; }
    }
}
