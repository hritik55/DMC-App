using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Diagnostic_Medical_Center.Models;
using Diagnostic_Medical_Center.ViewModel;

namespace Diagnostic_Medical_Center.Controllers
{
    
    public class RegistrationController : Controller
    {

        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Registration
        public ActionResult PatientRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PatientRegister(PatientRegisterViewModel patientView)
        {
            if (ModelState.IsValid)
            {
                
                var patient = new Patient()
                {
                    FirstName = patientView.FirstName,
                    LastName = patientView.LastName,
                    Age = patientView.Age,
                    PhoneNo = patientView.PhoneNo,
                    Sex = patientView.Sex,
                    UserId = patientView.UserId,
                    Password = patientView.Password,
                    RegistrationStatus = false
                };
                _context.Patients.Add(patient);
                _context.SaveChanges();
                
                return View();
            }
            else
                return View("Error");
        }

        public ActionResult AdminRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminRegister(AdminRegisterViewModel adminView)
        {
            if (ModelState.IsValid)
            {
                var admin = new Admin()
                {
                    FirstName = adminView.FirstName,
                    LastName = adminView.LastName,
                    Sex = adminView.Sex,
                    Age = adminView.Age,
                    PhoneNo = adminView.PhoneNo,
                    VendorId = adminView.VendorId,
                    Password = adminView.Password
                };
                var user = new User()
                {
                    UserId = adminView.VendorId,
                    Password = adminView.Password
                };

                _context.Admins.Add(admin);
                _context.SaveChanges();
                return View();
            }else
                return View("Error");
        }

        public ActionResult DoctorRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DocotrRegister(DoctorRegisterViewModel doctorView)
        {
            if (ModelState.IsValid)
            {
                var doctor = new Doctor()
                {
                    FirstName =  doctorView.FirstName,
                    LastName = doctorView.LastName,
                    Sex = doctorView.Sex,
                    Age = doctorView.Age,
                    PhoneNo = doctorView.PhoneNo,
                    UserId = doctorView.UserId,
                    Password = doctorView.Password,
                    RegistrationStatus = false
                };
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return View();
            }else
                return View("Error");
        }

        public ActionResult AgentRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgentRegister(AgentRegisterViewModel agentView)
        {
            if (ModelState.IsValid)
            {
                var agent = new Agent()
                {
                    FirstName = agentView.FirstName,
                    LastName = agentView.LastName,
                    Age = agentView.Age,
                    Sex = agentView.Sex,
                    PhoneNo = agentView.PhoneNo,
                    AgentId = agentView.AgentId,
                    Password = agentView.Password
                };
                _context.Agents.Add(agent);
                _context.SaveChanges();
                return View();
            }
            else
                return View("Error");

        }
    }
}