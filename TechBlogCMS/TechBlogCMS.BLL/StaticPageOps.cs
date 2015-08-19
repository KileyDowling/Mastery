using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;

namespace TechBlogCMS.BLL
{
    public class StaticPageOps
    {
        private IStaticPageRepo _repo;

        public StaticPageOps(IStaticPageRepo iStaticPage)
        {
            _repo = iStaticPage;
        }

        public List<StaticPage> GetAllStaticPages()
        {
            return _repo.GetAllStaticPages();
        }

        public StaticPage GetStaticPageById(int id)
        {
            List<StaticPage> temppagelist = new List<StaticPage>(GetAllStaticPages());
            
            var result = temppagelist.Where(tppl => tppl.StaticPageID == id);

            return result.FirstOrDefault();
        }

        public StaticPage GetStaticPageByTitle(string title)
        {
            List<StaticPage> temppageList = new List<StaticPage>(GetAllStaticPages());
            var result = temppageList.Where(tppl => tppl.StaticPageTitle == title.Replace("_", " "));
            return result.FirstOrDefault();
        }

        public void SaveStaticPage(StaticPage staticPage)
        {
            if (staticPage.DateOfPageCreation > new DateTime(01 / 01 / 2000))
                _repo.SaveStaticPage(staticPage);
        }
    }
}
