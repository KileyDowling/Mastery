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
    }
}
