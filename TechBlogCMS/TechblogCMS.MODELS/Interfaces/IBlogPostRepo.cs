using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogCMS.Models;

namespace TechblogCMS.MODELS.Interfaces
{
    public interface IBlogPostRepo
    {
        List<BlogPost> GetAllBlogPosts();

        void SaveBlogPost(BlogPost blog);

        List<BlogPost> ListAllBlogsInCategoryByCategoryId(int categoryId);

        List<BlogPost> ListAllBlogsByHashTag(int hashtagId);


    }
}
