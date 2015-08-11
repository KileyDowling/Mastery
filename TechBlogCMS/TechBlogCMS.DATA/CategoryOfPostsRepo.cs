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
                return cn.Query<CategoryOfPost>("Select * FROM CategoryOfPost").ToList();
            }
        }

        public void CreateCategory(CategoryOfPost newCategory)
        {

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query<CategoryOfPost>("insert into CategoryOfPost(CategoryType, CategoryDescription) Values (@catType, @catDesc)", new { catType = newCategory.CategoryType, catDesc = newCategory.CategoryDescription });
            }
        }

        public void SaveBlogPostCategory(int categoryId, int blogPostId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query("insert into PostCategories(CategoryID, BlogPostID) values(@catId, @blogId)",
                    new {catId = categoryId, blogId = blogPostId});
            }
        }

        public List<BlogPost> ListAllBlogsInCategoryByCategoryId(int categoryId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<BlogPost>("select * from BlogPost bp inner join PostCategories  pc on bp.BlogPostID = pc.BlogPostID inner join CategoryOfPost cp  on cp.CategoryID = pc.CategoryID where pc.CategoryID = @postCategoryId", new { postCategoryId = categoryId }).ToList();
            }
        }

    }
}
