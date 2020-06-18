using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
            
            bool isValid = _context.Users.Any(x => x.UserId == user.UserId && x.Password == user.Password);
            
            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(user.UserId, false);
                
                return RedirectToAction("GetAgentDetails", "Administration");
            }
            else
            {
                ModelState.AddModelError("","Invalid Username or Password");
                return View();
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Signin");
        }

    }
}