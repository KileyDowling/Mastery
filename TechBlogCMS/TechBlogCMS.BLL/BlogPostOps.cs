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

        public BlogPost GetBlogPostById(int id)
        {
            List<BlogPost> tempbloglist = new List<BlogPost>(GetAllBlogPosts());
            
            var result = tempbloglist.Where(tpbl => tpbl.BlogPostID == id);

            return result.FirstOrDefault();
        }


        public void SaveBlogPost(BlogPost blog)
        {
            if (blog.DateOfPost > new DateTime(01 / 01 / 2000))
                _repo.SaveBlogPost(blog);
        }

        public List<BlogPost> ListAllBlogsInCategoryByCategoryId(int categoryId)
        {
            return _repo.ListAllBlogsInCategoryByCategoryId(categoryId);

        }

        public List<BlogPost> ListAllBlogsByHashTag(int hashtagId)
        {
            return _repo.ListAllBlogsByHashTag(hashtagId);
        }

        public void EditBlogPost(BlogPost blog)
        {
            _repo.EditBlogPost(blog);
        }

        public void DeleteBlogPost(int blogPostId)
        {
            _repo.DeleteBlogPost(blogPostId);
        }
    }
}
