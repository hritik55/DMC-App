using Diagnostic_Medical_Center.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diagnostic_Medical_Center.Controllers
{
    public class AgentsController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Agents
        public ActionResult AgentIndex()
        {
            return View();
        }


        public ActionResult ViewDoctors()
        {
            var allDoctors = _context.Doctors.Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.PhoneNo,
                x.Sex,
                x.IsAvailable
            }).ToList();

            return View(allDoctors);
        }
    }
}