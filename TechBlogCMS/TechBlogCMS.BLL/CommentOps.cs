using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.DATA;
using TechBlogCMS.Models;

namespace TechBlogCMS.BLL
{
    public class CommentOps
    {
        private ICommentRepo _repo;

        public CommentOps(ICommentRepo iComment)
        {
            _repo = iComment;
        }

        public List<Comment> GetAllCommentsByBlogPostID(int blogPostId)
        {
            return _repo.GetAllCommentsByPostID(blogPostId);
        }

        public List<Comment> GetAllComments()
        {
            return _repo.GetAllComments();
        }

        public void CreateComment(Comment comment)
        {
            if(comment.DateOfComment >= DateTime.Today)
                _repo.CreateComment(comment);
        }

        public void DeleteComment(int id)
        {
            _repo.DeleteComment(id);
        }

        public void ApproveComment(int commentId, int statusId)
        {
            _repo.ApproveComment(commentId, statusId);
        }
    }
}
