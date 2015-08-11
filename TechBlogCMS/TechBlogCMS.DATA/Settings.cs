using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogCMS.DATA
{
    public class Settings
    {
        private static string _connectionString = "";

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                }
                return _connectionString;

            }
        }
    }
}
