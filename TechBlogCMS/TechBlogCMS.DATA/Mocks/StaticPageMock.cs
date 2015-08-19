using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechblogCMS.MODELS;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;

namespace TechBlogCMS.DATA.Mocks
{
    public class StaticPageMock : IStaticPageRepo
    {
        public List<StaticPage> GetAllStaticPages()
        {
            return new List<StaticPage>()
            {
                new StaticPage()
                {
                    StaticPageID = 1,
                    StaticPageTitle = "Static Page Number 1",
                    StaticPageContent = "<p>Disclaimer!</p>",
                    DateOfPageCreation = new DateTime(1997, 07, 25)
                },
                
                new StaticPage()
                {
                    StaticPageID = 2,
                    StaticPageTitle = "Static Page Number 2",
                    StaticPageContent = "<p>Do not do any of this!</p>",
                    DateOfPageCreation = new DateTime(2000, 05, 14)
                }, 
                
                new StaticPage()
                {
                    StaticPageID = 3,
                    StaticPageTitle = "Static Page Number 3",
                    StaticPageContent = "<p>DYou should do things like this!</p>",
                    DateOfPageCreation = new DateTime(2015, 8, 17)
                },
                

            };
        }
        public StaticPage GetStaticPageById(int staticPageId)
        {
            throw new NotImplementedException();
        }

        public void SaveStaticPage(StaticPage staticPage)
        {
            
        }
    }
}
