using Diagnostic_Medical_Center.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Diagnostic_Medical_Center.Controllers
{
    
    public class DoctorsController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Doctors
        public ActionResult DoctorsIndex()
        {
            return View();
        }

       


    }
}