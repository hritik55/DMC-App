using Diagnostic_Medical_Center.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diagnostic_Medical_Center.Controllers
{
    public class TestRequestController : Controller
    {
        // GET: TestRequest
        [HttpPost]
        public ActionResult AddTestRequest()
        {


            return View();
        }


        [HttpPost]
        public ActionResult AddTestRequest(TestRequest request)
        {


            return View();
        }
    }
}