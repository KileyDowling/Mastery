using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;

namespace TechBlogCMS.BLL
{
    public class HashtagOps
    {
        private IHashtagRepo _repo;

        public HashtagOps(IHashtagRepo ihashtag)
        {
            _repo = ihashtag;
        }

        public List<Hashtag> ListAllHashtags()
        {
            return _repo.ListAllHashtags();
        }

        public void CreateHashtag(Hashtag newHashtag)
        {
            if (!string.IsNullOrEmpty(newHashtag.HashtagType))
                _repo.CreateHashtag(newHashtag);

        }
    }
}
