using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;
using TechblogCMS.MODELS;

namespace TechBlogCMS.DATA.Mocks
{
    public class CommentMock : ICommentRepo
    {
        public void DeleteComment(int id)
        {

        }


        public List<Comment> GetAllComments()
        {
            return new List<Comment>();
        }
        public List<Comment> GetAllCommentsByPostID(int id)
        {
            return new List<Comment>()
            {
                new Comment()
                {
                    CommentID = 1,
                    BlogPostID = 1,
                    CommentContent = "This is our first comment",
                    Status = new Status() {StatusID=1},
                    User = new User(),
                    Nickname = "Sadukie"

                },

                new Comment()
                {
                    CommentID = 2,
                    BlogPostID = 1,
                    CommentContent = "This is our second comment",
                    Status = new Status() {StatusID=1},
                    User = new User(),
                    Nickname = "JakeSaliga"

                },
                new Comment()
                {
                    CommentID = 3,
                    BlogPostID = 1,
                    CommentContent = "This is our third comment",
                    Status = new Status() {StatusID=1},
                    User = new User(),
                    Nickname = "Sadukie"

                },
            };
        }

        public void CreateComment(Comment comment)
        {
            
        }


        public void ApproveComment(int commentId, int statusId)
        {
            throw new NotImplementedException();
        }
    }
}
