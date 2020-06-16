using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Diagnostic_Medical_Center.Models;

namespace Diagnostic_Medical_Center.Controllers
{
    
    public class RegistrationController : Controller
    {

        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Registration
        public ActionResult PatientRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PatientRegister(Patient patient)
        {
            if (!ModelState.IsValid)
            {

            }

            return View();
        }

       
    }
}