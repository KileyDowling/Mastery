using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS.Interfaces;
using Dapper;
using TechBlogCMS.Models;

namespace TechBlogCMS.DATA
{
    public class StatusRepo : IStatusRepo
    {
        public List<Status> GetAllStatuses()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<Status>("SELECT * FROM [TechBlogCMS].[dbo].[Status]").ToList();
            }
        }
    }
}
