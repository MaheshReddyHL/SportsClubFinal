using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports2.Controllers
{
    public class SoccermasterController : Controller
    {
        // GET: Soccermaster
        public ActionResult Index()
        {
            return new FilePathResult("~/Views/Soccermaster/index.html","text/html");
        }
    }
}