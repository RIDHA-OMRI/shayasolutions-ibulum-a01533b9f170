using IBulum_v1.Helpers;
using IBulum_v1.Models;
using IBulum_v1.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBulum_v1.Controllers
{
    public class HomeController : Controller
    {
        private DbInitializer dbInit = new DbInitializer();
        public ActionResult Index()
        {
            //dbInit.DbInit();
            //dbInit.AddUserRoles();
            //dbInit.AddUsers();
            //dbInit.AddInquiries();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}