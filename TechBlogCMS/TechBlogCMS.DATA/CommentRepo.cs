using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;
using TechblogCMS.MODELS;


namespace TechBlogCMS.DATA
{
    public class CommentRepo : ICommentRepo
    {
        public List<Comment> GetAllComments()
        {
            var list = new List<Comment>();
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand("select c.CommentID, c.BlogPostID, c.StatusID, s.StatusType, c.UserID,c.Nickname,c.DateOfComment, c.CommentContent from Comment c inner join Status s on c.StatusID = s.StatusID", cn);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var comment = new Comment()
                        {
                            Status = new Status(),
                            User = new User()
                        };
                        comment.CommentID = dr.GetInt32(0);
                        comment.BlogPostID = dr.GetInt32(1);
                        comment.Status.StatusID = dr.GetInt32(2);
                        comment.Status.StatusType = dr.GetString(3);
                        comment.User.UserId = dr["UserID"] is DBNull ? String.Empty : dr.GetString(7);
                        comment.Nickname = dr.GetString(5);
                        comment.DateOfComment = dr.GetDateTime(6);
                        comment.CommentContent = dr.GetString(7);

                        list.Add(comment);
                    }
                }
            }
            return list;
        }


        public List<Comment> GetAllCommentsByPostID(int blogPostId)
        {
            var list = new List<Comment>();
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand("select c.CommentID, c.BlogPostID, c.StatusID, s.StatusType, c.UserID,c.Nickname,c.DateOfComment, c.CommentContent from Comment c inner join Status s on c.StatusID = s.StatusID where c.BlogPostID = @id", cn);
                cmd.Parameters.AddWithValue("@id", blogPostId);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var comment = new Comment()
                        {
                            Status = new Status(),
                            User = new User()
                        };
                        comment.CommentID = dr.GetInt32(0);
                        comment.BlogPostID = dr.GetInt32(1);
                        comment.Status.StatusID = dr.GetInt32(2);
                        comment.Status.StatusType = dr.GetString(3);
                        comment.User.UserId = dr["UserID"] is DBNull ? String.Empty : dr.GetString(4);
                        comment.Nickname = dr.GetString(5);
                        comment.DateOfComment = dr.GetDateTime(6);
                        comment.CommentContent = dr.GetString(7);

                        list.Add(comment);
                    }  
            }
        }
            return list;

        }

        public void CreateComment(Comment comment)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query(
                    "INSERT INTO Comment(BlogPostID, CommentContent, StatusID, Nickname, DateOfComment) VALUES (@PostID, @Content, @Status, @Name, @Date)",
                    new {PostID = comment.BlogPostID, Content = comment.CommentContent, Status = comment.Status.StatusID, Name = comment.Nickname, Date = comment.DateOfComment});
            }
        }

        public void DeleteComment(int id)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query("delete Comment where CommentId = @commentId", new { commentId = id });
            }
        }

        public void ApproveComment(int commentId, int statusId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query("update Comment SET StatusID =  @statId  WHERE CommentID = @id", new { statId = statusId, id = commentId });
            }
        }
    }
}
