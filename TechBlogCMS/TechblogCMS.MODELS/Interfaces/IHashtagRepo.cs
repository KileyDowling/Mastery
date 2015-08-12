using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogCMS.Models;

namespace TechblogCMS.MODELS.Interfaces
{
    public interface IHashtagRepo
    {
        List<Hashtag> ListAllHashtags();

        void CreateHashtag(Hashtag newHashtag);

        void SaveBlogPostHashtags(List<int> hashtagIds, int blogPostId);

        List<Hashtag> ListAllHashtagsForBlogPost(int blogId);

    }
}
