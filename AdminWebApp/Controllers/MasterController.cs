﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWebApp.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult UserRegistration()
        {
            return View();
        }
    }
}