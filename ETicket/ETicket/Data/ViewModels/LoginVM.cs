using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]  // this hides the text in the input box
        public string Password { get; set; }

    }
}
