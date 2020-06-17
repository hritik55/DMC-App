using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Diagnostic_Medical_Center.Models
{
    public class Role : IdentityRole
    {
        public const string AdminRoleName = "Administrator";
        public const string DoctorRoleName = "Doctor";
        public const string PatientRoleName = "Patient";
    }
}