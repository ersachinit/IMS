using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWebApp.Controllers
{
    public class AdminAccessController : Controller
    {
        // GET: AdminAccess
        public ActionResult Masters()
        {
            return View();
        }
    }
}