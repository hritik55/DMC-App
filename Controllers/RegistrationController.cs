using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Diagnostic_Medical_Center.Models;

namespace Diagnostic_Medical_Center.Controllers
{
    [AllowAnonymous]
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
        public ActionResult PatientRegister(Patient patientView)
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
                        Password = System.Web.Helpers.Crypto.Hash(patientView.Password),
                        RegistrationStatus = false,
                        ConfirmPassword = System.Web.Helpers.Crypto.Hash(patientView.Password),
                        RoleID = 3
                    };
                var idExists = _context.Patients.Any(x => x.UserId == patient.UserId);
                if (!idExists)
                {
                    _context.Patients.Add(patient);
                    _context.SaveChanges();
                    ViewBag.ValidationMessage = "Your Details are saved successfully";
                    ModelState.Clear();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User Id Already Exists! Try another name.");
                    patient.UserId = string.Empty;
                    patient.Password = string.Empty;
                }
               
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Check your details and try again");
            }

            return View();
        }

        public ActionResult AdminRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminRegister(Admin adminView)
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
                    RegistrationStatus = true,
                    Password = System.Web.Helpers.Crypto.Hash(adminView.Password),
                    ConfirmPassword = System.Web.Helpers.Crypto.Hash(adminView.Password),
                    RoleId = 1
                };
                var idExists = _context.Admins.Any(x => x.VendorId == adminView.VendorId);

                if (!idExists)
                {
                    var user = new User()
                    {
                        UserId = admin.VendorId,
                        Password = admin.Password,
                        RoleId = admin.RoleId
                    };
                    try
                    { 
                        _context.Admins.Add(admin);
                        _context.Users.Add(user);
                        _context.SaveChanges();
                        ViewBag.ValidationMessage = "Your Details are submitted successfully.";
                        ModelState.Clear();
                    }
                    catch(Exception e)
                    {
                        ModelState.AddModelError(string.Empty, "Something went wrong!");
                    }
                 
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User Id Already Exists! Try another name.");
                    admin.VendorId = string.Empty;
                    admin.Password = string.Empty;
                }

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Check your details and try again");
            }

            return View();
        }

        public ActionResult DoctorRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoctorRegister(Doctor doctorView)
        {
            if (ModelState.IsValid)
            {
                var doctor = new Doctor()
                {
                    FirstName = doctorView.FirstName,
                    LastName = doctorView.LastName,
                    Sex = doctorView.Sex,
                    Age = doctorView.Age,
                    PhoneNo = doctorView.PhoneNo,
                    DoctorId = doctorView.DoctorId,
                    Password = System.Web.Helpers.Crypto.Hash(doctorView.Password),
                    RegistrationStatus = false,
                    ConfirmPassword = System.Web.Helpers.Crypto.Hash(doctorView.Password),
                    RoleId = 2
                };

                var idExists = _context.Doctors.Any(x => x.DoctorId == doctorView.DoctorId);

                if (!idExists)
                {
            
                    _context.Doctors.Add(doctor);
                    _context.SaveChanges();
                    ViewBag.ValidationMessage = "Your Details are saved successfully";
                    ModelState.Clear();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User Id Already Exists! Try another name.");
                    doctor.DoctorId = string.Empty;
                    doctor.Password = string.Empty;
                }
              
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Check your details and try again");
            }

            return View();
        }

        public ActionResult AgentRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgentRegister(Agent agentView)
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
                    Password = System.Web.Helpers.Crypto.Hash(agentView.Password),
                    RegistrationStatus = false,
                    ConfirmPassword = System.Web.Helpers.Crypto.Hash(agentView.Password),
                    RoleId = 4
                };

                var idExists = _context.Agents.Any(x => x.AgentId == agentView.AgentId);

                if (!idExists)
                {
                    _context.Agents.Add(agent);
                    _context.SaveChanges();
                    ViewBag.ValidationMessage = "Your Details are saved successfully";
                    ModelState.Clear();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User Id Already Exists! Try another name.");
                    agent.AgentId = string.Empty;
                    agent.Password = string.Empty;
                }
               
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Check your details and try again");
            }

            return View();
        }

    }
}