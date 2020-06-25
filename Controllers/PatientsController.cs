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

        public ActionResult ViewAppointments()
        {
            var user = (Patient)Session["User"];
            var appointments = _context.Appointments.Where(a => a.PatientId == user.UserId).ToList();
            foreach(var a in appointments)
            {
                if (a.Approved == true && a.Completed == false)
                {
                    ViewBag.Status = "Your Appointment has been Approved";
                    break;
                }
                //else if (a.Approved == false && a.Completed == true)
                //{
                //    ViewBag.Status = "Your Appointment has been Rejected";
                //    break;
                //}
                //else if (a.Approved == true && a.Completed == true)
                //{
                //    ViewBag.Status = "Contact your Doctor or Agent for Test Results.";
                //    break;
                //}
                //else if (a.Approved == false && a.Completed == false)
                //{
                //    ViewBag.Status = "Pending for Approval";
                //    break;
                //}
                //else
                //    ViewBag.Status = null;
            }
            return View(appointments);
        }



    }
}