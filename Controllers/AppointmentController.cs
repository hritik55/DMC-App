using Diagnostic_Medical_Center.Models;
using Diagnostic_Medical_Center.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diagnostic_Medical_Center.Controllers
{
    
    public class AppointmentController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Appointment
        public ActionResult BookAppointment()
        {
            //OldMethod
            var allServices = _context.MedicareServices.Select(s => new { s.ServiceID, s.ServiceName}).ToList();
            var allDoctors = _context.Doctors.Select(d => new { d.DoctorId, d.FirstName, d.LastName}).ToList();
            ViewBag.Services = allServices;
            ViewBag.Doctors = allDoctors;
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookAppointment(Appointment appointment)
        {
            //var username = (Patient)Session["User"];
            
            if (ModelState.IsValid)
            {
                var newAppointment = new Appointment();
                newAppointment.MedicareID = appointment.MedicareID;
                newAppointment.DoctorId = appointment.DoctorId;
                newAppointment.PatientId = appointment.PatientId;
                newAppointment.AppointmentDay = appointment.AppointmentDay.Date;
                newAppointment.Approved = false;
                newAppointment.Completed = false;
                _context.Appointments.Add(newAppointment);
                _context.SaveChanges();
                ModelState.Clear();
            }
            else
            {
                ModelState.AddModelError(string.Empty,"Something went wrong");
            }

            return RedirectToAction("BookAppointment");
        }

        //[HttpGet]
        public ActionResult PopulateDropDown(int id)
        {

            return View();
        }

        public ActionResult FillDoctors(int id)
        {
            var doctorId = _context.MedicareServices.Where(m => m.ServiceID == id).Select(d => d.DoctorId).FirstOrDefault();
            var doctor = _context.Doctors.Where(d => d.DoctorId == doctorId).Select(x => new { x.DoctorId, x.FirstName, x.LastName }).FirstOrDefault();

            if (doctor != null)
            {
                return Json(doctor, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { data = "No Doctors Available" }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetDoctorsDropDown(int? id)
        {
            var doctorId = _context.MedicareServices.Where(m => m.ServiceID == id).Select(d => d.DoctorId).FirstOrDefault();
            var doctor = _context.Doctors.Where(d => d.DoctorId == doctorId).Select(x => new { x.DoctorId, x.FirstName, x.LastName }).FirstOrDefault();

            if (doctor != null)
            {
                return Json(doctor, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { data = "No Doctors Available" }, JsonRequestBehavior.AllowGet);
           
        }


    }
}