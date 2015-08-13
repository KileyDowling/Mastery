using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TechblogCMS.MODELS;
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
                            Status = new Status(),
                            User = new User()
                        };
                        blog.User.UserId = dr.GetString(0);
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
            var repo = new UserRepo();
            foreach (var blog in blogPosts)
            {
                var id = blog.User.UserId;
                blog.User = repo.GetUserById(id);
                blog.User.UserId = id;
            }
            return blogPosts;
        }

        public BlogPost GetBlogPostById(int blogPostId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand("Select b.UserID, b.PostContent,b.StatusID,s.StatusType, b.DateOfPost, b.PostTitle, b.BlogPostID from Blogpost b inner join [Status] s  on b.StatusID= s.StatusID where b.BlogPostID = BlogPostID order by b.DateOfPost desc", cn);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var blog = new BlogPost()
                        {
                            Status = new Status(),
                            User = new User()
                        };
                        blog.User.UserId = dr.GetString(0);
                        blog.PostContent = dr.GetString(1);
                        blog.Status.StatusID = dr.GetInt32(2);
                        blog.Status.StatusType = dr.GetString(3);
                        blog.DateOfPost = dr.GetDateTime(4);
                        blog.PostTitle = dr.GetString(5);
                        blog.BlogPostID = dr.GetInt32(6);

                        return blog;
                    }
                }

            }
            //var repo = new UserRepo();
            //{
            //    var id = blog.User.UserId;
            //    blog.User = repo.GetUserById(id);
            //    blog.User.UserId = id;
            //}

            return null;
        }
    

        public void SaveBlogPost(BlogPost blog)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@UserId", blog.User.UserId);
                p.Add("@PostContent", blog.PostContent);
                p.Add("@StatusID", blog.Status.StatusID);
                p.Add("@DateOfPost", blog.DateOfPost);
                p.Add("@PostTittle", blog.PostTitle);

                cn.Query("SubmitNewBlogPost", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<BlogPost> ListAllBlogsInCategoryByCategoryId(int categoryId)
        {
            var blogPosts = new List<BlogPost>();
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand("select bp.UserID, bp.PostContent,bp.StatusID, s.StatusType,bp.DateOfPost,bp.PostTitle,bp.BlogPostID,u.UserName, u.FirstName,u.LastName from BlogPost bp inner join PostCategories pc on bp.BlogPostID = pc.BlogPostID inner join CategoryOfPost cp  on cp.CategoryID = pc.CategoryID inner join AspNetUsers u on u.Id = bp.UserID inner join [Status] s on s.StatusID = bp.StatusID where pc.CategoryID =@catId order by bp.DateOfPost desc", cn);
                cmd.Parameters.AddWithValue("@catId", categoryId);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var blog = new BlogPost()
                        {
                            Status = new Status(),
                            User = new User()
                        };
                        blog.User.UserId = dr.GetString(0);
                        blog.PostContent = dr.GetString(1);
                        blog.Status.StatusID = dr.GetInt32(2);
                        blog.Status.StatusType = dr.GetString(3);
                        blog.DateOfPost = dr.GetDateTime(4);
                        blog.PostTitle = dr.GetString(5);
                        blog.BlogPostID = dr.GetInt32(6);
                        blog.User.UserName = dr.GetString(7);
                        blog.User.FirstName = dr.GetString(8);
                        blog.User.LastName = dr.GetString(9);

                        blogPosts.Add(blog);
                    }
                }

            }
            return blogPosts;

        }

        public List<BlogPost> ListAllBlogsByHashTag(int hashtagId)
        {
            var blogPosts = new List<BlogPost>();
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand("select bp.UserID, bp.PostContent,bp.StatusID,  s.StatusType, bp.DateOfPost, bp.PostTitle, bp.BlogPostID, u.UserName, u.FirstName,u.LastName from BlogPost bp inner join PostHashtags ph on bp.BlogPostID = ph.BlogPostID inner join Hashtag h  on h.HashtagID = ph.HashtagID inner join AspNetUsers u on u.Id = bp.UserID inner join [Status] s on s.StatusID = bp.StatusID where ph.HashtagID =@hashId order by bp.DateOfPost desc", cn);
                cmd.Parameters.AddWithValue("@hashId", hashtagId);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var blog = new BlogPost()
                        {
                            Status = new Status(),
                            User = new User()
                        };
                        blog.User.UserId = dr.GetString(0);
                        blog.PostContent = dr.GetString(1);
                        blog.Status.StatusID = dr.GetInt32(2);
                        blog.Status.StatusType = dr.GetString(3);
                        blog.DateOfPost = dr.GetDateTime(4);
                        blog.PostTitle = dr.GetString(5);
                        blog.BlogPostID = dr.GetInt32(6);
                        blog.User.UserName = dr.GetString(7);
                        blog.User.FirstName = dr.GetString(8);
                        blog.User.LastName = dr.GetString(9);

                        blogPosts.Add(blog);
                    }
                }

            }
            return blogPosts;

        }

        public void EditBlogPost(BlogPost blog)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand(
                    "UPDATE [dbo].[BlogPost]" +
                    "SET [PostContent] = @PostContent," +
                    "[StatusID] = @StatusId," +
                    "[DateOfPost] = @DateOfPost," +
                    "[PostTitle] = @PostTitle" +
                    "WHERE [BlogPostID] = @BlogPostId)");
                cmd.Parameters.AddWithValue("@PostContent", blog.PostContent);
                cmd.Parameters.AddWithValue("@StatusId", blog.Status);
                cmd.Parameters.AddWithValue("@DateOfPost", blog.DateOfPost);
                cmd.Parameters.AddWithValue("@PostTitle", blog.PostTitle);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBlogPost(int blogId)
        {
            DeletePostCategories(blogId);
            DeletePostHashtags(blogId);

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query("delete BlogPost where BlogPostID = @blogPost", new { blogPost = blogId });
            }
        }

        public void DeletePostCategories(int blogId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query("delete PostCategories where BlogPostID = @blogPost", new {blogPost = blogId});
            }
        }

        public void DeletePostHashtags(int blogId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query("delete PostHashtags where BlogPostID = @blogPost", new { blogPost = blogId });
            }
        }
    }


}
