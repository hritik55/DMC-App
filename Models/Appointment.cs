using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagnostic_Medical_Center.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentOn { get; set; }
        public bool status { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public bool ApprovalStatus { get; set; }
    }
}