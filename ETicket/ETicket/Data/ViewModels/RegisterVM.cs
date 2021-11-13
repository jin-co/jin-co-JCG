using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "FullName required")]
        public string FullName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]  // this hides the text in the input box
        public string Password { get; set; }

        [Display(Name = "Confirm")]
        [Required(ErrorMessage = "Confirm required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "password mismatch")]
        public string ConfirmPassword { get; set; }

    }
}
