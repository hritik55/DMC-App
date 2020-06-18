using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Diagnostic_Medical_Center.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDoctor { get; set; }
        public bool IsAgent { get; set; }
        public bool IsPatient { get; set; }

    }
}