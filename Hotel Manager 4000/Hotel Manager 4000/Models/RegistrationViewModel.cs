using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Manager_4000.Models
{
    public class RegistrationViewModel
    {

        [Required(ErrorMessage ="Please enter a email.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please enter an username")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        [Required(ErrorMessage ="Please enter a password")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string? Password { get; set; }
        [Required(ErrorMessage ="Please enter your password again ")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
