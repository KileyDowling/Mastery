using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;

namespace TechBlogCMS.DATA.Mocks
{
    public class BlogPostMock : IBlogPostRepo
    {

        public List<BlogPost> GetAllBlogPosts()
        {
            return new List<BlogPost>()
            {
                new BlogPost()
                {
                    BlogPostID = 1,
                    PostTitle = "Blog Number 1",
                    PostContent = "<p>Hello World!</p>",
                    DateOfPost = new DateTime(1997, 07, 25)
                },
                new BlogPost()
                {
                    BlogPostID = 2,
                    PostTitle = "Blog Number 2",
                    PostContent = "<p>Hola Worldo!</p>",
                    DateOfPost = new DateTime(2000, 05, 13)
                },
                new BlogPost()
                {
                    BlogPostID = 3,
                    PostTitle = "Blog Number 3",
                    PostContent = "<p>This is a blog post!</p>",
                    DateOfPost = new DateTime(2015, 08, 05)
                }

            };
        }

        public BlogPost GetBlogPostById(int blogPostId)
        {
            throw new NotImplementedException();
        }

        public void SaveBlogPost(BlogPost blog)
        {
        }

        public List<BlogPost> ListAllBlogsInCategoryByCategoryId(int categoryId)
        {
            return new List<BlogPost>();
        }


        public List<BlogPost> ListAllBlogsByHashTag(int hashtagId)
        {
            return new List<BlogPost>();
        }

        public void EditBlogPost(BlogPost blog)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlogPost(int blogPostId)
        {
            throw new NotImplementedException();
        }
    }
}
