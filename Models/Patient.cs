using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Diagnostic_Medical_Center.Models
{
    public class Patient
    { 

        [Required(ErrorMessage = "Enter Your Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter your age")]
        public int Age { get; set; }
        public Gender Sex { get; set; }
        [Required(ErrorMessage = "Contact No is Required")]
        [RegularExpression("\\d{10}")]
        public string PhoneNo { get; set; }
        public bool RegistrationStatus { get; set; }
        [Required(ErrorMessage = "Enter a UserId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserId { get; set; }
        [Required( ErrorMessage ="Enter a valid Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public int RoleID {get; set; }
        public UserRole UserRole { get; set; }
        
    }
     
}