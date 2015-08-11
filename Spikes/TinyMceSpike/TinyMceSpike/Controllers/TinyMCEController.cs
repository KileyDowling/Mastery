using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinyMceSpike.Models;

namespace TinyMceSpike.Controllers
{
    public class TinyMCEController : Controller
    {
        // GET: TinyMCE
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ExampleClass model)
        {
            return View();
        }
    }
}