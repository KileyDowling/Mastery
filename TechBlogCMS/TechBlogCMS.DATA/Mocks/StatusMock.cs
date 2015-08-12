using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;

namespace TechBlogCMS.DATA.Mocks
{
    public class StatusMock : IStatusRepo
    {

        public List<Status> GetAllStatuses()
        {
            return new List<Status>()
            {
                new Status() {StatusID = 1, StatusType = "Submitted"},
                new Status() {StatusID = 2, StatusType = "Approved"},
                new Status() {StatusID = 3, StatusType = "Rejected "}
            };
        }


        public void UpdateStatus(int blogPostId, int newStatusId)
        {
            throw new NotImplementedException();
        }
    }
}
