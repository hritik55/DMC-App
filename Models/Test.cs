﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diagnostic_Medical_Center.Models
{
    public class Test
    {
        [Key] 
        public int TestId { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        public bool isActiveRequest { get; set; }
        public string Description { get; set; }
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}