using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogCMS.Models;

namespace TechblogCMS.MODELS.Interfaces
{
    public interface ICategoryOfPostRepo
    {
        List<CategoryOfPost> ListAllCategories();

        void CreateCategory(CategoryOfPost category);

        void SaveBlogPostCategory(List<int> categoryIds, int blogPostId);

        List<CategoryOfPost> ListAllCategoriesForBlogPost(int blogId);

    }
}
