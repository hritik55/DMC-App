using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diagnostic_Medical_Center.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public int MedicareID { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public MedicareService Service { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Appointment")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AppointmentDay { get; set; }
        public bool Approved { get; set; }
        public bool Completed { get; set; }
    }
}