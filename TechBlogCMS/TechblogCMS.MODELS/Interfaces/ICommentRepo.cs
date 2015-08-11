using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechBlogCMS.Models;

namespace TechblogCMS.MODELS.Interfaces
{
    public interface ICommentRepo
    {
        List<Comment> GetAllCommentsByPostID(int id);
        void CreateComment(Comment comment);
    }
}
