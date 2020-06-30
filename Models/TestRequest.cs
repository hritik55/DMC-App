using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diagnostic_Medical_Center.Models
{
    public class TestRequest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DoctorId { get; set; }
        [Required]
        public string PatientId { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        
        public string result { get; set; }

        public string baseValue { get; set; }

        public bool isActiveRequest { get; set; }

        public Appointment Appointment { get; set; }
    }
}