using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;

namespace TechBlogCMS.BLL
{
    public class BlogPostOps
    {
        private IBlogPostRepo _repo;

        public BlogPostOps(IBlogPostRepo iBlog)
        {
            _repo = iBlog;
        }

        public List<BlogPost> GetAllBlogPosts()
        {
            return _repo.GetAllBlogPosts();
        }

        public void SaveBlogPost(BlogPost blog)
        {
            if(blog.DateOfPost > new DateTime(01/01/2000))
                _repo.SaveBlogPost(blog);
        }
    }
}
