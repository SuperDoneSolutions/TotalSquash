using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotalSquash.Models;

namespace TotalSquash.Controllers
{
    public class LandingPageController : Controller
    {
        //
        // GET: /LandingPage/
        private PrimarySquashDBContext db = new PrimarySquashDBContext();
        public ActionResult Index()
        {
            return View();
        }
	}
}