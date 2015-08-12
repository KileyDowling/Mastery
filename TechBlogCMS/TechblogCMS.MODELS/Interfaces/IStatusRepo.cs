using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogCMS.Models;

namespace TechblogCMS.MODELS.Interfaces
{
    public interface IStatusRepo
    {
        List<Status> GetAllStatuses();
        void UpdateStatus(int blogPostId, int newStatusId);

    }
}
