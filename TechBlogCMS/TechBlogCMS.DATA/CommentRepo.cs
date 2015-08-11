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
    public class CommentRepo : ICommentRepo
    {
        public List<Comment> GetAllCommentsByPostID(int blogPostId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<Comment>("SELECT * FROM Comment WHERE BlogPostID = @id", new {id = blogPostId}).ToList();
            }
        }

        public void CreateComment(Comment comment)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query(
                    "INSERT INTO Comment(BlogPostID, CommentContent, StatusID, UserID, Nickname, DateOfComment) VALUES (@PostID, @Content, @Status, @User, @Name, @Date)",
                    new {PostID = comment.BlogPostID, Content = comment.CommentContent, Status = comment.StatusID, User = comment.UserID, Name = comment.Nickname, Date = comment.DateOfComment});
            }
        }
    }
}
