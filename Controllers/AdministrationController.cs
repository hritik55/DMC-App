using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diagnostic_Medical_Center.Models;
using System.Data.Entity;
using System.Net;

namespace Diagnostic_Medical_Center.Controllers
{
    
    public class AdministrationController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Administration
        public ActionResult Index()
        {
            try
            {
                if (Session["User"] != null)
                {
                    var currentUser = Session["User"] as Admin;
                    ViewBag.Username = currentUser.FirstName;
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        //Agent
        public ActionResult GetAgentDetails()
        {
            List<Agent> agentList = _context.Agents.Where(a => a.RegistrationStatus == false).ToList();

            return View("GetAgentDetails",agentList);
        }

        
        public ActionResult AcceptAgent(string id)
        {
            var pendingAgent =  _context.Agents.Single(x=>x.AgentId == id);
            pendingAgent.RegistrationStatus = true;
            pendingAgent.ConfirmPassword = pendingAgent.Password;
            User user = new User()
            {
                UserId = pendingAgent.AgentId,
                Password = pendingAgent.Password,
                RoleId =4               
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

       
        public ActionResult RejectAgent(string id)
        {
            var acceptStatus = _context.Agents.Single(x => x.AgentId == id);
            //acceptStatus.ConfirmPassword = acceptStatus.Password;
            //acceptStatus.RegistrationStatus = false;
            _context.Agents.Remove(acceptStatus);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        //Patient
        public ActionResult GetPatientDetails()
        {
            List<Patient> patientList = _context.Patients.Where(a => a.RegistrationStatus == false).ToList();

            return View("GetPatientDetails", patientList);
            
        }



        public ActionResult AcceptPatient(string id)
        {
            var pendingPatient = _context.Patients.Single(x => x.UserId == id);
            pendingPatient.RegistrationStatus = true;
            pendingPatient.ConfirmPassword = pendingPatient.Password;
            User user = new User()
            {
                UserId = pendingPatient.UserId,
                Password = pendingPatient.Password,
                RoleId = 3
            };
            _context.Users.Add(user);
            _context.SaveChanges(); 
            return RedirectToAction("Index");
        }


        public ActionResult RejectPatient(string id)
        {
            var acceptStatus = _context.Patients.Single(x => x.UserId == id);
            acceptStatus.ConfirmPassword = acceptStatus.Password;
            if (acceptStatus.RegistrationStatus)
            {
                acceptStatus.RegistrationStatus = false;
                if (_context.Users.Any(x => x.UserId == id))
                {
                    var rejectedUser = _context.Users.Single(x => x.UserId == id);
                    _context.Users.Remove(rejectedUser);
                    
                }
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //Doctor
        public ActionResult GetDoctorDetails()
        {
            List<Doctor> doctorList = _context.Doctors.Where(a => a.RegistrationStatus == false).ToList();
            return View("GetDoctorDetails", doctorList);
        }


        public ActionResult AcceptDoctor(string id)
        {
            var pendingDoctor = _context.Doctors.Single(x => x.DoctorId== id);
            pendingDoctor.ConfirmPassword = pendingDoctor.Password;
            pendingDoctor.RegistrationStatus = true;
            User user = new User()
            {
                UserId = pendingDoctor.DoctorId,
                Password = pendingDoctor.Password,
                RoleId = 2

            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult RejectDoctor(string id)
        {
            var pendingDoctor = _context.Doctors.Single(x => x.DoctorId == id);
            pendingDoctor.RegistrationStatus = false;
            pendingDoctor.ConfirmPassword = pendingDoctor.Password;
            _context.Doctors.Remove(pendingDoctor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Admin
        public ActionResult GetAdminDetails()
        {
            List<Admin> adminList = _context.Admins.Where(a => a.RegistrationStatus == false).ToList();
            return View("GetAdminDetails", adminList);
        }

        public ActionResult ViewTestRequests()
        {
            var appointments = _context.Appointments.Where(a => a.Approved == true && a.Completed == false).ToList();
            return View(appointments);
        }

        [HttpGet]
        public ActionResult UpdateTestResults(int id)
        {
            var Exists = _context.TestRequests.Any(x => x.Id == id);
            if(id != 0 && !Exists)
            {

                var testInfo = _context.Appointments.Find(id);
                TestRequest newRequestData = new TestRequest()
                {
                   
                    DoctorId = testInfo.DoctorId,
                    PatientId = testInfo.PatientId,
                    AppointmentId = testInfo.Id,
                    result = "",
                    baseValue = "",

                }; 
                return View(newRequestData);
            }
            else
            {

                return View();
            }
           
        }

        [HttpPost]
        public ActionResult UpdateTestResults(TestRequest request)
        {
            if (ModelState.IsValid)
            {
                var appointmentToRemove = _context.Appointments.Where(x => x.Id == request.Id).FirstOrDefault();
                _context.TestRequests.Add(request);
                appointmentToRemove.Completed = true;
                //_context.Appointments.Remove(appointmentToRemove);
                _context.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = "Test Results have been successfully updated!";
            }

            return View();
           
        }


        public ActionResult AcceptAdmin(string id)
        {
            var pendingAdmin = _context.Admins.Single(x => x.VendorId == id);
            pendingAdmin.RegistrationStatus = true;
            pendingAdmin.ConfirmPassword = pendingAdmin.Password;
            User user = new User()
            {
                UserId = pendingAdmin.VendorId,
                Password = pendingAdmin.Password,
                RoleId = 1
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult RejectAdmin(string id)
        {
            var pendingAdmin = _context.Admins.Single(x => x.VendorId == id);
            pendingAdmin.RegistrationStatus = false;

            _context.Admins.Remove(pendingAdmin);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult CreateAgent()
        {
            var agent = _context.Agents.ToList();
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        public ActionResult EditAgent(string id)
        {
            var agent = _context.Agents.Where(a => a.AgentId == id).FirstOrDefault();
            return View(agent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAgent(Agent agent)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var agentInDb = _context.Agents.Single(a => a.AgentId == agent.AgentId);
                    agentInDb.FirstName = agent.FirstName;
                    agentInDb.LastName = agent.LastName;
                    agentInDb.PhoneNo = agent.PhoneNo;
                    agentInDb.Age = agent.Age;
                    agentInDb.ConfirmPassword = agentInDb.Password;
                    ViewBag.ValidationMessage = "Your changes have been saved!";
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }catch(Exception e)
            {
            
                ModelState.AddModelError(string.Empty, "Check your details and Try Again!");
                
            }
           
            return View(agent);

        }






    }

   
}
