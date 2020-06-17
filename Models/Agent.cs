using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diagnostic_Medical_Center.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [Required]
        public Gender Sex { get; set; }
        public string PhoneNo { get; set; }
        public bool RegistrationStatus { get; set; }
        public string AgentId { get; set; }
        public string Password { get; set; }
    }
}