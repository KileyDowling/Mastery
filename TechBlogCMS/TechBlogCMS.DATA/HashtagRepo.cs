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
    public class HashtagRepo : IHashtagRepo
    {
        public List<Hashtag> ListAllHashtags()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<Hashtag>("Select * FROM Hashtag").ToList();
            }
        }


        public void CreateHashtag(Hashtag newHashtag)
        {

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query<Hashtag>("insert into Hashtag(HashtagType,HashtagDescription) Values (@hashType, @hashDesc)", 
                    new { hashType = newHashtag.HashtagType, hashDesc = newHashtag.HashtagDescription });
            }
        }
    }
}
