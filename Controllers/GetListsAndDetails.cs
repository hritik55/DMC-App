using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diagnostic_Medical_Center.Models;

namespace Diagnostic_Medical_Center.Controllers
{
    
    public class GetListsAndDetails
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public List<MedicareService> GetMedicareServices()
        {
            var services = _context.MedicareServices.ToList();
            return services;
        }

        public List<Doctor> GetDoctorsList()
        {
            var doctors = _context.Doctors.ToList();
            return doctors;
        }

        public List<Agent> GetAgentList()
        {
            var agents = _context.Agents.ToList();
            return agents;
        }

        public List<Appointment> GetAppointments(string id)
        {
           if(id == null)
            {
                var allAppointments = _context.Appointments.ToList();
                return allAppointments;
            }
            else
            {
                return null;
            }
        }
    }
}