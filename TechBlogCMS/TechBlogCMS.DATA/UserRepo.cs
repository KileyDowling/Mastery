using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TechblogCMS.MODELS;
using TechblogCMS.MODELS.Interfaces;

namespace TechBlogCMS.DATA
{
    public class UserRepo : IUserRepo
    {
        public List<User> GetAllUsers()
        {
            var user = new List<User>();
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand("GetAllUsers", cn) {CommandType = CommandType.StoredProcedure};

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    var aspUser = new User
                    {
                        UserId = dr.GetString(0),
                        Email = dr.GetString(1),
                        PhoneNumber  = dr.GetString(2),
                        UserName = dr.GetString(3),
                        FirstName = dr.GetString(4),
                        LastName = dr.GetString(5)
                    };
                    
                    user.Add(aspUser);
                }
            }
            return user;
        }

        public User GetUserById(string id)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<User>("Select * FROM Aspnetusers where id = @userId", new {userId = id}).ToList().FirstOrDefault();
            }
        }
    }
}
