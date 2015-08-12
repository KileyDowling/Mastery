using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;

namespace TechBlogCMS.BLL
{
    public class StatusOps
    {
        private IStatusRepo _repo;

        public StatusOps(IStatusRepo iStatus)
        {
            _repo = iStatus;
        }

        public List<Status> ListAllStatuses()
        {
            return _repo.GetAllStatuses();
        }

        public void UpdateStatus(int blogPostId, int newStatusId)
        {
            _repo.UpdateStatus(blogPostId, newStatusId);
        }
    }
}
