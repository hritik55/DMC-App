using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using Diagnostic_Medical_Center.Models;

namespace Diagnostic_Medical_Center.Controllers
{
    
    [AllowAnonymous]
    public class LoginManagerController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: LoginManager


        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(User user)
        {
            try
            {

                var validUser = _context.Users.Where(a => a.UserId == user.UserId).FirstOrDefault();

                if (validUser != null)
                {
                    if (string.Compare(System.Web.Helpers.Crypto.Hash(user.Password), validUser.Password) == 0)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserId, false);

                        switch (validUser.RoleId)
                        {
                            case 1:
                                Admin a = _context.Admins
                                    .Where(x => x.VendorId == user.UserId)
                                    .FirstOrDefault();
                                Session["User"] = a;
                                return RedirectToAction("Index", "Administration");
                            case 2:
                                Doctor d = _context.Doctors
                                    .Where(o => o.DoctorId == user.UserId)
                                    .FirstOrDefault();
                                Session["User"] = d;
                                return RedirectToAction("DoctorsIndex", "Doctors");
                            case 3:
                                Patient p = _context.Patients
                                    .Where(e => e.UserId == user.UserId)
                                    .FirstOrDefault();
                                Session["User"] = p;
                                return RedirectToAction("PatientsIndex", "Patients");
                            case 4:
                                Agent g = _context.Agents
                                    .Where(t => t.AgentId == user.UserId)
                                    .FirstOrDefault();
                                Session["User"] = g;
                                return RedirectToAction("AgentIndex", "Agents");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Passwords do not match");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                }

            }catch(Exception e)
            {
                ModelState.AddModelError("", "Invalid Username or Password");
            }

                    return View();
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            ViewBag.User = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Signin");
        }

    }
}