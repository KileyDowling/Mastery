using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TechblogCMS.MODELS.Interfaces
{
    public interface IUserRepo
    {
        List<User> GetAllUsers();

        User GetUserById(string id);
    }
}
