using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogCMS.Models
{
    public class EmployeeTitle
    {
        public int EmployeeTitleID { get; set; }
        public string EmployeeTitleType { get; set; }
        public string EmployeeTitleDescription { get; set; }
    }
}
