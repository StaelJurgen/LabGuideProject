using System;
using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Labogids.Api.DTOs.Accounts
{
    public class AccountsRegisterRequestDto : AccountsLoginRequestDto
    {
        [Required(ErrorMessage = "Please provide {0}")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please provide {0}")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please provide {0}")]
        [EmailAddress(ErrorMessage = "Please provide a valid {0}")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide {0}")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please provide {0}")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please provide {0}")]
        public int PostalCode { get; set; }
        [Required(ErrorMessage = "Please provide {0}")]
        public string City { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string RepeatPassword { get; set; }
    }
}
