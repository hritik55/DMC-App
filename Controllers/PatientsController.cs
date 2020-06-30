using Diagnostic_Medical_Center.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using System.Net;

namespace Diagnostic_Medical_Center.Controllers
{
    
    public class PatientsController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        GetListsAndDetails _fetchdetails = new GetListsAndDetails();
        // GET: Patients
        public ActionResult PatientsIndex()
        {
            if(Session["User"] != null)
            {
                var currentUser = Session["User"] as Patient;
                ViewBag.Username = currentUser.FirstName;
            }
            return View();
        }

        public ActionResult GetDoctorsList()
        {
            return View(_fetchdetails.GetDoctorsList());
        }

        public ActionResult GetAgentList()
        {
            return View(_fetchdetails.GetAgentList());
        }

        public ActionResult GetServiceList()
        {
            return View(_fetchdetails.GetMedicareServices());
        }

        public ActionResult GetDoctorDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = _context.Doctors.Single(a => a.DoctorId == id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        public ActionResult GetAgentDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = _context.Agents.Single(a => a.AgentId == id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        public ActionResult GetMedicareDetails(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicareService service = _context.MedicareServices.Single(a => a.ServiceID == id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }


        public ActionResult BookAppointment()
        {

            var currentUser = Session["User"] as Patient;
            ViewBag.Username = currentUser.FirstName;
            var allServices = _context.MedicareServices.Select(s => new { s.ServiceID, s.ServiceName }).ToList();
            var allDoctors = _context.Doctors.Select(d => new { d.DoctorId, d.FirstName, d.LastName }).ToList();
            ViewBag.Services = allServices;
            ViewBag.Doctors = allDoctors;

            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookAppointment(Appointment appointment)
        {
            var tempUser = (Patient)Session["User"];
            ViewBag.Username = tempUser.FirstName;

            if (ModelState.IsValid)
            {
                var newAppointment = new Appointment();
                newAppointment.MedicareID = appointment.MedicareID;
                newAppointment.DoctorId = appointment.DoctorId;
                newAppointment.PatientId = tempUser.UserId;
                newAppointment.AppointmentDay = appointment.AppointmentDay.Date;
                newAppointment.Approved = false;
                newAppointment.Completed = false;
                _context.Appointments.Add(newAppointment);
                _context.SaveChanges();
                ModelState.Clear();
                ViewBag.SuccessMessage = "Your Appointment has been Successfully Booked!";
                
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Something went wrong, Please try again.");
            }

            return RedirectToAction("BookAppointment");
        }


    public ActionResult ViewAppointments()
        {
            var user = (Patient)Session["User"];
            var appointments = _context.Appointments.Where(a => a.PatientId == user.UserId).ToList();
            foreach(var a in appointments)
            {
                if (a.Approved == false && a.Completed == false)
                {
                    ViewBag.Pending = "Your Appointment is pending for approval";
                    
                }else if(a.Approved == true && a.Completed == false)
                {
                    ViewBag.Approved = "Your appointment has been Approved.";
                    
                }else if(a.Approved == false && a.Completed == true)
                {
                    ViewBag.Rejected = "Your Appoinment has been Rejected";
                    
                }else if(a.Approved == true && a.Completed == true)
                {
                    ViewBag.Done = "Check your results";
                }
            }
            return View(appointments);
        }

        public ActionResult ViewTestResults()

        {
            var tempUser = (Patient)Session["User"];
            ViewBag.Username = tempUser.FirstName;
            var testList = _context.TestRequests.Where(r => r.PatientId == tempUser.UserId).ToList();
            return View(testList);
        }
        

    }
}