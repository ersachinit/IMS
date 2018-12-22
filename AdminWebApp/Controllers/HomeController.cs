using AdminWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWebApp.Controllers
{
    [RequireHttps]
    public class HomeController : ApplicationBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "Dashboard";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }
        public ActionResult SachinTripathi()
        {
            return View();
        }
    }
}