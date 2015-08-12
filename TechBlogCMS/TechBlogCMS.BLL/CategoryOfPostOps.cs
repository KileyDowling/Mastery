using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;

namespace TechBlogCMS.BLL
{
    public class CategoryOfPostOps
    {
        private ICategoryOfPostRepo _repo;

        public CategoryOfPostOps(ICategoryOfPostRepo icategory)
        {
            _repo = icategory;
        }

        public List<CategoryOfPost> ListAllCategories()
        {
            return _repo.ListAllCategories();
        }

        public void CreateCategory(CategoryOfPost category)
        {
            if (!string.IsNullOrEmpty(category.CategoryType))
                _repo.CreateCategory(category);
                
        }

        public void SaveBlogPostCategory(List<int>  categoryIds , BlogPost blog)
        {
            var ops = OperationsFactory.CreateBlogPostOps();
            var list = ops.GetAllBlogPosts();
            var lastPost = list.FirstOrDefault(x => x.PostTitle == blog.PostTitle);

            if(lastPost !=null)
                _repo.SaveBlogPostCategory(categoryIds,lastPost.BlogPostID);
        }

  

        public List<CategoryOfPost> ListAllCategoriesForBlogPost(int blogId)
        {
            return _repo.ListAllCategoriesForBlogPost(blogId);
        }
    }
}
