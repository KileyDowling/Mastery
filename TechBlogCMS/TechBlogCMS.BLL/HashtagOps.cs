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

        public void SaveBlogPostHashtags(List<int> hashtagIds, BlogPost blog)
        {
            var ops = OperationsFactory.CreateBlogPostOps();
            var list = ops.GetAllBlogPosts();
            var lastPost = list.FirstOrDefault(x => x.PostTitle == blog.PostTitle);

            if (lastPost != null)
                _repo.SaveBlogPostHashtags(hashtagIds, lastPost.BlogPostID);
        }

        public List<Hashtag> ListAllHashtagsForBlogPost(int blogId)
        {
            return _repo.ListAllHashtagsForBlogPost(blogId);
        }

    }
}
