using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;

namespace TechBlogCMS.DATA.Mocks
{
    public class CategoryMock : ICategoryOfPostRepo
    {
        public List<CategoryOfPost> ListAllCategories()
        {
            return new List<CategoryOfPost>
            {
                new CategoryOfPost()
                {
                    CategoryID = 1,
                    CategoryType = "Technology",
                    CategoryDescription = "All things technology"
                },
                new CategoryOfPost()
                {
                    CategoryID = 2,
                    CategoryType = "MVC",
                    CategoryDescription = "Model View Controller"
                },
                new CategoryOfPost()
                {
                    CategoryID = 3,
                    CategoryType = "Datebase",
                    CategoryDescription = "All things database"
                },
            };
        }


        public void CreateCategory(CategoryOfPost category)
        {
        }

        public void SaveBlogPostCategory(List<int> categoryIds, int blogPostId)
        {
            
        }





        public List<CategoryOfPost> ListAllCategoriesForBlogPost(int blogId)
        {
            return new List<CategoryOfPost>();
        }
    }
}
