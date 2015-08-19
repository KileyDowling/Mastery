using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TechblogCMS.MODELS;
using TechblogCMS.MODELS.Interfaces;
using TechBlogCMS.Models;

namespace TechBlogCMS.DATA
{
    public class StaticPageRepo : IStaticPageRepo
    {
        public List<StaticPage> GetAllStaticPages()
        {
            var staticPages = new List<StaticPage>();
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand("Select p.UserId, p.StaticPageContent, p.StatusID, s.StatusType, p.DateOfPageCreation, p.StaticPageTitle, p.StaticPageID from StaticPage p inner join [Status] s  on p.StatusID= s.StatusID order by p.DateOfPageCreation desc", cn);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var staticPage = new StaticPage()
                        {
                            Status = new Status(),
                            User = new User()
                        };
                        staticPage.User.UserId = dr.GetString(0);
                        staticPage.StaticPageContent= dr.GetString(1);
                        staticPage.Status.StatusID = dr.GetInt32(2);
                        staticPage.Status.StatusType = dr.GetString(3);
                        staticPage.DateOfPageCreation = dr.GetDateTime(4);
                        staticPage.StaticPageTitle = dr.GetString(5);
                        staticPage.StaticPageID = dr.GetInt32(6);

                        staticPages.Add(staticPage);
                    }
                }

            }
            var repo = new UserRepo();
            foreach (var page in staticPages)
            {
                var id = page.User.UserId;
                page.User = repo.GetUserById(id);
                page.User.UserId = id;
            }
            return staticPages;
        }

        public StaticPage GetStaticPageById(int staticPageId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd =
                    new SqlCommand(
                        "Select p.UserID, p.StaticPageContent,p.StatusID,s.StatusType, p.DateOfPageCreation, p.StaticPageTitle, p.StaticPageID from StaticPage p inner join [Status] s  on p.StatusID= s.StatusID where p.StaticPageID = StaticPageID order by p.DateOfPageCreation desc",
                        cn);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var staticPage = new StaticPage();
                        {
                            //Status = new Status(),
                            //User = new User()
                        };
                        staticPage.User.UserId= dr.GetString(0);
                        staticPage.StaticPageContent = dr.GetString(1);
                        staticPage.Status.StatusID = dr.GetInt32(2);
                        staticPage.Status.StatusType = dr.GetString(3);
                        staticPage.DateOfPageCreation = dr.GetDateTime(4);
                        staticPage.StaticPageTitle = dr.GetString(5);
                        staticPage.StaticPageID = dr.GetInt32(6);

                        return staticPage;
                    }
                }

            }
            return null;
        }

        public void SaveStaticPage(StaticPage staticPage)
            {
                using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("@UserId", staticPage.User.UserId);
                    p.Add("@StaticPageContent", staticPage.StaticPageContent);
                    p.Add("@StatusID", staticPage.Status.StatusID);
                    p.Add("@DateOfPageCreation", staticPage.DateOfPageCreation);
                    p.Add("@StaticPageTitle", staticPage.StaticPageTitle);

                    cn.Query("SaveStaticPage", p, commandType: CommandType.StoredProcedure);
                }
            }


       
    }
}
