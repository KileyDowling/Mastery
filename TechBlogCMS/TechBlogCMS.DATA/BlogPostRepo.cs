using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;

namespace TechBlogCMS.DATA
{

    public class BlogPostRepo : IBlogPostRepo
    {

        public List<BlogPost> GetAllBlogPosts()
        {
            var blogPosts = new List<BlogPost>();
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand("Select b.UserID, b.PostContent,b.StatusID,s.StatusType, b.DateOfPost, b.PostTitle, b.BlogPostID from Blogpost b inner join [Status] s  on b.StatusID= s.StatusID order by b.DateOfPost desc", cn);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var blog = new BlogPost()
                        {
                            Status = new Status()
                        };
                        blog.UserID = dr.GetString(0);
                        blog.PostContent = dr.GetString(1);
                        blog.Status.StatusID = dr.GetInt32(2);
                        blog.Status.StatusType = dr.GetString(3);
                        blog.DateOfPost = dr.GetDateTime(4);
                        blog.PostTitle = dr.GetString(5);
                        blog.BlogPostID = dr.GetInt32(6);

                        blogPosts.Add(blog);
                    }
                }

            }
            return blogPosts;
        }

        public void SaveBlogPost(BlogPost blog)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@UserId", blog.UserID);
                p.Add("@PostContent", blog.PostContent);
                p.Add("@StatusID", blog.Status.StatusID);
                p.Add("@DateOfPost", blog.DateOfPost);
                p.Add("@PostTittle", blog.PostTitle);

                cn.Query("SubmitNewBlogPost", p, commandType: CommandType.StoredProcedure);
            }
        }


    }


}
