using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Manager_4000.Models
{
    public class RegistrationViewModel
    {

        [Required(ErrorMessage ="Please enter a email.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please enter an username")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage ="Please enter a password")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Please enter your password again ")]
        public string RepeatPassword { get; set; }
    }
}
