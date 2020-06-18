using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diagnostic_Medical_Center.Models;

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

        public ActionResult GetAgentDetails()
        {
            List<Agent> agentList = (from agents in _context.Agents select agents).ToList();
            return View(agentList);
        }

        
        public ActionResult AcceptAgent(string id)
        {
            var pendingAgent =  _context.Agents.Single(x=>x.AgentId == id);
            pendingAgent.RegistrationStatus = true;
            User user = new User()
            {
                UserId = pendingAgent.AgentId,
                Password = pendingAgent.Password
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("GetAgentDetails");
        }

       
        public ActionResult RejectAgent(string id)
        {
            var acceptStatus = _context.Agents.Single(x => x.AgentId == id);
            acceptStatus.RegistrationStatus = false;
            _context.SaveChanges();
            return RedirectToAction("GetAgentDetails");
        }
    }
}