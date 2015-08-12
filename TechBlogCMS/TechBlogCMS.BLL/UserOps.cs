using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS;
using TechblogCMS.MODELS.Interfaces;

namespace TechBlogCMS.BLL
{
    public class UserOps
    {
        public IUserRepo _repo;

        public UserOps(IUserRepo iRepo)
        {
            _repo = iRepo;
        }

        public User GetUserById(string id)
        {
            return _repo.GetUserById(id);
        } 
    }
}
