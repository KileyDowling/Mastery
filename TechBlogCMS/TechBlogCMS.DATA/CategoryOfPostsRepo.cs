using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;

namespace TechBlogCMS.DATA
{
    public class CategoryOfPostsRepo : ICategoryOfPostRepo
    {
        public List<CategoryOfPost> ListAllCategories()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<CategoryOfPost>("Select * FROM CategoryOfPost ORDER BY CategoryType").ToList();
            }
        }

        public void CreateCategory(CategoryOfPost newCategory)
        {

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query<CategoryOfPost>("insert into CategoryOfPost(CategoryType, CategoryDescription) Values (@catType, @catDesc)", new { catType = newCategory.CategoryType, catDesc = newCategory.CategoryDescription });
            }
        }

        public void SaveBlogPostCategory(List<int> categoryIds , int blogPostId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                foreach (var id in categoryIds)
                {
                    cn.Query("insert into PostCategories(CategoryID, BlogPostID) values(@catId, @blogId)",
                    new { catId = id, blogId = blogPostId });
                }
                
            }
        }

       


        public List<CategoryOfPost> ListAllCategoriesForBlogPost(int blogId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                return
                    cn.Query<CategoryOfPost>(
                        "select cp.CategoryType, cp.CategoryDescription,cp.CategoryID from PostCategories pc inner join BlogPost bp on pc.BlogPostID = bp.BlogPostID inner join CategoryOfPost cp on cp.CategoryID = pc.CategoryID where bp.BlogPostID = @postId",
                        new { postId = blogId }).ToList();
            }
        }
    }
}
