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
                cn.Query<Hashtag>("insert into Hashtag(HashtagType) Values (@hashType)", 
                    new { hashType = newHashtag.HashtagType});
            }
        }

        public void SaveBlogPostHashtags(List<int> hashtagIds, int blogPostId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                foreach (var id in hashtagIds)
                {
                    cn.Query("insert into PostHashtags(HashtagID, BlogPostID) values(@hashId, @blogId)",
                    new { hashId = id, blogId = blogPostId });
                }

            }
        }


        public List<Hashtag> ListAllHashtagsForBlogPost(int blogId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                return
                    cn.Query<Hashtag>(
                        "select ht.HashtagType,ht.HashtagID from PostHashtags ph inner join BlogPost bp on ph.BlogPostID = bp.BlogPostID inner join Hashtag ht on ht.HashtagID = ph.HashtagID where bp.BlogPostID = @postId",
                        new { postId = blogId }).ToList();
            }
        }
    }


}
