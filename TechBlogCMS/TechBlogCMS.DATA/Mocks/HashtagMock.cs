using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;

namespace TechBlogCMS.DATA.Mocks
{
    public class HashtagMock : IHashtagRepo
    {
        public List<Hashtag> ListAllHashtags()
        {
            return new List<Hashtag>()
            {
                new Hashtag()
                {
                    HashtagID = 1,
                    HashtagType = "#computers",
                    HashtagDescription = "#computers"

                },
                new Hashtag()
                {
                   HashtagID = 2,
                   HashtagType = "#technology",
                   HashtagDescription = "#technology"
                },
                new Hashtag ()
                {
                    HashtagID = 3,
                    HashtagType = "#randomthoughts",
                    HashtagDescription = "#randomthoughts"
                }
            };
        }


        public void CreateHashtag(Hashtag newHashtag)
        {
        }


        public void SaveBlogPostHashtags(List<int> hashtagIds, int blogPostId)
        {
        }
    }
}
