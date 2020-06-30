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
                ViewBag.SuccessMessage = "Your Appoinment has been Successfully Booked!";
                return View();
            }
            else
            {
                ModelState.AddModelError(string.Empty,"Something went wrong, Please try again.");
            }

            return RedirectToAction("BookAppointment");
        }

    }
}