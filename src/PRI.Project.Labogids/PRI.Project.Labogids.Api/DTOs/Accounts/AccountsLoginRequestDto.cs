using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Labogids.Api.DTOs.Accounts
{
    public class AccountsLoginRequestDto
    {
        [Required(ErrorMessage = "Please provide {0}")]
        [EmailAddress(ErrorMessage = "Please provide a valid {0}")]
        public string UserName { get; set; } // emailaddress

        [Required(ErrorMessage = "Please provide {0}")]
        public string Password { get; set; }
    }
}
