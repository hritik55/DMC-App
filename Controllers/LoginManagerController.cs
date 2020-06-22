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
            var validUser = _context.Users.Where(a => a.UserId == user.UserId).FirstOrDefault();

            if(validUser != null)
            {
                if(string.Compare(Crypto.Hash(user.Password),validUser.Password) == 0)
                {
                    FormsAuthentication.SetAuthCookie(user.UserId, false);
                    switch (validUser.RoleId)
                    {
                        case 1:
                            return RedirectToAction("Index", "Administration");
                        case 2:
                            return RedirectToAction("DoctorsIndex", "Doctors");
                        case 3:
                            return RedirectToAction("PatientsIndex", "Patients");
                        case 4:
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
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Signin");
        }

    }
}