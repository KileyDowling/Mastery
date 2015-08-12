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


        public void UpdateStatus(int blogPostId, int newStatusId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query<Status>("update BlogPost SET StatusID = @StatId WHERE BlogPostID = @PostId", new { StatId = newStatusId, PostId = blogPostId});
            }
        }
    }
}
