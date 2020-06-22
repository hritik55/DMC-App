using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diagnostic_Medical_Center.Models;
using System.Data.Entity;

namespace Diagnostic_Medical_Center.Controllers
{
    
    public class AdministrationController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }


        //Agent
        public ActionResult GetAgentDetails()
        {
            List<Agent> agentList = (from agents in _context.Agents select agents).ToList();

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
            return RedirectToAction("GetAgentDetails");
        }

       
        public ActionResult RejectAgent(string id)
        {
            var acceptStatus = _context.Agents.Single(x => x.AgentId == id);
            acceptStatus.ConfirmPassword = acceptStatus.Password;
            acceptStatus.RegistrationStatus = false;

            _context.SaveChanges();
            return RedirectToAction("GetAgentDetails");
        }


        //Patient
        public ActionResult GetPatientDetails()
        {
            List<Patient> patientList = (from patients in _context.Patients select patients).ToList();

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
            return RedirectToAction("GetPatientDetails");
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

            return RedirectToAction("GetPatientDetails");
        }

        //Doctor
        public ActionResult GetDoctorDetails()
        {
            List<Doctor> doctorList = (from doctors in _context.Doctors select doctors).ToList();
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
            return RedirectToAction("GetDoctorDetails");
        }


        public ActionResult RejectDoctor(string id)
        {
            var pendingDoctor = _context.Doctors.Single(x => x.DoctorId == id);
            pendingDoctor.RegistrationStatus = false;
            pendingDoctor.ConfirmPassword = pendingDoctor.Password;

            _context.SaveChanges();
            return RedirectToAction("GetDoctorDetails");
        }

        //Admin
        public ActionResult GetAdminDetails()
        {
            List<Admin> adminList = (from admins in _context.Admins select admins).ToList();
            return View("GetAdminDetails", adminList);
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
            return RedirectToAction("GetAdminDetails");
        }


        public ActionResult RejectAdmin(string id)
        {
            var pendingAdmin = _context.Admins.Single(x => x.VendorId == id);
            pendingAdmin.RegistrationStatus = false;


            _context.SaveChanges();
            return RedirectToAction("GetAdminDetails");
        }

        public ActionResult UpdateAgent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAgent([Bind(Include = "FirstName,LastName,Age,Sex,PhoneNo,RegistrationStatus")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(agent).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return View(agent);
        }
    }

   
}
