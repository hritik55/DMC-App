﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diagnostic_Medical_Center.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("LandingPage");
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

        public ActionResult AdminLogin()
        {
            return View("Login");
        }
        
    }
}