using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;

namespace TechBlogCMS.DATA.Mocks
{
    public class CommentMock : ICommentRepo
    {
        public List<Comment> GetAllCommentsByPostID(int id)
        {
            return new List<Comment>()
            {
                new Comment()
                {
                    CommentID = 1,
                    BlogPostID = 1,
                    CommentContent = "This is our first comment",
                    StatusID = 1,
                    UserID = 1,
                    Nickname = "Sadukie"

                },

                new Comment()
                {
                    CommentID = 2,
                    BlogPostID = 1,
                    CommentContent = "This is our second comment",
                    StatusID = 1,
                    UserID = 2,
                    Nickname = "JakeSaliga"

                },
                new Comment()
                {
                    CommentID = 3,
                    BlogPostID = 1,
                    CommentContent = "This is our third comment",
                    StatusID = 1,
                    UserID = 1,
                    Nickname = "Sadukie"

                },
            };
        }

        public void CreateComment(Comment comment)
        {
            
        }
    }
}
