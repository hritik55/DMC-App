using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diagnostic_Medical_Center.Models
{
    public class Agent
    {
     
        [Required(ErrorMessage = "Enter Your Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter your age")]
        public int Age { get; set; }
        [Required]
        public Gender Sex { get; set; }
        [Required(ErrorMessage = "Contact No is Required")]
        [RegularExpression("\\d{10}")]
        public string PhoneNo { get; set; }
        public bool RegistrationStatus { get; set; }
        [Required(ErrorMessage = "Enter your Agent Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AgentId { get; set; }

        [Required(ErrorMessage = "Enter a valid Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
   
        public int RoleId { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public UserRole UserRoles { get; set; }
    }
}