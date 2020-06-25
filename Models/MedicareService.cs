using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Diagnostic_Medical_Center.Models
{
    public class MedicareService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceID { get; set; }

        [Required(ErrorMessage ="Please Provide a Name to the Service ")]
        public string ServiceName { get; set; }

        public string Eligibility { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}