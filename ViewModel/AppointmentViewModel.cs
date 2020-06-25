using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diagnostic_Medical_Center.Models;

namespace Diagnostic_Medical_Center.ViewModel
{
    public class AppointmentViewModel
    {
        
        
        public List<DoctorsViewModel> Services { get; set; }
        public SelectList FilteredServices { get; set; }

    }

    public class DoctorsViewModel
    {
        public string Id { get; set; }
        public string DoctorName { get; set; }
    }
}