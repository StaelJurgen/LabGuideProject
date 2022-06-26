using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRI.Project.Labogids.Api.DTOs.Accounts;
using PRI.Project.Labogids.Core.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("auth/register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(AccountsRegisterRequestDto accountsRegisterRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var result = await _userService.Register(
                accountsRegisterRequestDto.FirstName,
                accountsRegisterRequestDto.LastName,
                accountsRegisterRequestDto.UserName,
                accountsRegisterRequestDto.Email,
                accountsRegisterRequestDto.DateOfBirth,
                accountsRegisterRequestDto.Address,
                accountsRegisterRequestDto.PostalCode,
                accountsRegisterRequestDto.City,
                accountsRegisterRequestDto.Password);

            if (result.IsSuccess) { return Ok(result.Messages.First()); }
            return BadRequest(result.Messages.First());
        }

        [HttpPost("auth/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AccountsLoginRequestDto accountsLoginRequestDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState.Values); }

            var result = await _userService.Login(accountsLoginRequestDto.UserName,
                accountsLoginRequestDto.Password);

            if (result.IsSuccess)
            {
                return Ok(new AccountsLoginResponseDto
                {
                    Token = result.Messages.ToArray()[0],
                    Claims = result.Messages.ToArray()[1]
                });
            }

            return Unauthorized(result.Messages);
        }
    }
}
