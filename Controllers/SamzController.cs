using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diagnostic_Medical_Center.Models;

namespace Diagnostic_Medical_Center.Controllers
{
    public class SamzController : Controller
    {
        public ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Samz
        public ActionResult Roles()
        {
           tempModel tobj = new tempModel();
           tobj.ListOfRoles = _context.UserRoles.ToList();
           tobj.SelectedAnswer = "";
           return View(tobj);

        }

        [HttpPost]
        public ActionResult RoleRegister(string SelectedAnswer)
        {
            
            if (SelectedAnswer == "Doctor")
            {
                return RedirectToAction("DoctorRegister", "Registration");
            }
            else if (SelectedAnswer == "Patient")
            {
                return RedirectToAction("PatientRegister", "Registration");
            }
            else
                return View("Roles");
        }

    }
}