using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppRegisLogin.Models
{
    public class UserModel
    {
        
        public int UserId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required.")]
        [Display(Name ="First Name:")]
        public String FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Required.")]
        [Display(Name = "Last Name:")]
        public String LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required.")]
        [Display(Name = "Email:")]
        public String Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required.")]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm-Password is Required.")]
        [Display(Name = "Confirm Password:")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm Password should be same")]
        public String ConfirmPassword { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public string  SuccessMessage { get; set; }
    }
}