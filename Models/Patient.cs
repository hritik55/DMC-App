﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diagnostic_Medical_Center.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        public Gender Sex { get; set; }
        [Required]
        
        public string PhoneNo { get; set; }
        public bool RegistrationStatus { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        
        public ICollection<Appointment> Appointments { get; set; }
    }
}