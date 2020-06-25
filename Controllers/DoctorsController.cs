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
        GetListsAndDetails _fetchdetails = new GetListsAndDetails();
        // GET: Doctors
        public ActionResult DoctorsIndex()
        {
            if (Session["User"] != null)
            {
                var currentUser = Session["User"] as Doctor;
                ViewBag.Username = currentUser.FirstName;
                return View();
            }
            else
                return View();
        }

        public ActionResult CreateMedicareService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMedicareService( MedicareService service)
        {
            var serviceExists = _context.MedicareServices.Where(s => s.ServiceID == service.ServiceID).FirstOrDefault();
            var tempUser = Session["User"] as Doctor;

            if(ModelState.IsValid && serviceExists == null)
            {
                service.DoctorId = tempUser.DoctorId;
                _context.MedicareServices.Add(service);
                _context.SaveChanges();
                ViewBag.ValidationMessage = "The Service has been successfully added!";
                ModelState.Clear();
            }
            else
            {
                ModelState.AddModelError(string.Empty,"Check the details provided and Try Again!");
            }

            return View();
        }

        public ActionResult ShowMedicareServices()
        {
            return View(_fetchdetails.GetMedicareServices());
        }

        public ActionResult EditMedicareService(int? id)
        {
            var service = _context.MedicareServices.Where(s => s.ServiceID == id).FirstOrDefault();
            if(service != null)
            {
                return View(service);
            }
            else
            {
                ViewBag.Error = "Service no longer exists!";
                return View();
            }
        }


        [HttpPost]
        public ActionResult EditMedicareService([Bind(Include ="ServiceId, ServiceName, Eligibility, DoctorId")] MedicareService service)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(service).State = EntityState.Modified;
                _context.SaveChanges();
                ViewBag.ValidationMessage = "Your Details are submitted successfully!";
                return RedirectToAction("DoctorsIndex", "Doctors");
            }
            else
                ModelState.AddModelError(string.Empty, "Check the details provided and Try Again.");

            return View(service);
        }


        public ActionResult ShowAllAppointments()
        {
            var user = (Doctor)Session["User"];
            var appointments = _context.Appointments.Where(a => a.DoctorId == user.DoctorId).ToList();
            return View(appointments);
        }


        public ActionResult AcceptPatient(int id)
        {
            var pendingAppointment = _context.Appointments.Single(x => x.Id == id);
            pendingAppointment.Approved = true;
            _context.SaveChanges();
            return RedirectToAction("DoctorsIndex");
        }


        public ActionResult RejectPatient(int id)
        {
            var pendingAppointment = _context.Appointments.Single(x => x.Id == id);
            pendingAppointment.Approved = false;
            _context.Appointments.Remove(pendingAppointment);
            _context.SaveChanges();
            return RedirectToAction("DoctorsIndex");
        }

        public ActionResult Completed(int id)
        {
            
            var pendingAppointment = _context.Appointments.Single(x => x.Id == id);
            if(pendingAppointment.Approved == true)
            {
                pendingAppointment.Completed = true;
               _context.Appointments.Remove(pendingAppointment);
                _context.SaveChanges();
            }
           
            return RedirectToAction("DoctorsIndex");
        }

    }
}