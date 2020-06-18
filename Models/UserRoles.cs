using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diagnostic_Medical_Center.Models
{
    public class UserRoles
    {
        [Key]
        public int Id { get; set; }
        public string UserRoleName { get; set; }
    }
}