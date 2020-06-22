using Diagnostic_Medical_Center.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

namespace Diagnostic_Medical_Center.Controllers
{
    
    public class PatientsController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Patients
        public ActionResult PatientsIndex()
        {
            return View();
        }

        public JsonResult GetDoctorsList()
        {
            List<Doctor> DoctorList = _context.Doctors.ToList();
            return Json(DoctorList, JsonRequestBehavior.AllowGet);
        }
     

    

        
    }
}