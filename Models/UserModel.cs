using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login_RegisterApplication.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Age is required.")]
        [Display(Name = "Age: ")]
        public int Age { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm-Password is required.")]
        [Display(Name = "Confirm-Password: ")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm-Passwrod does not match")]
        public string ConfirmPassword { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone No. is required.")]
        [Display(Name = "Phone: ")]
        public long Phone { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required.")]
        [Display(Name = "City: ")]
        public string City { get; set; }

        public DateTime CreatedOn { get; set; }

        public string SuccessMessage { get; set; }
    }


}