using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Interfaces.Services;
using PRI.Project.Labogids.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<AuthenticateResultModel> Register(string firstname, string lastname, string username, string email, DateTime dateOfBirth, string address, int postalCode, string city, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                return new AuthenticateResultModel { Messages = new List<string> { "Registration failed" } };
            }

            var newUser = new ApplicationUser
            {
                UserName = username,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                DateOfBirth = dateOfBirth,
                Address = address,
                PostalCode = postalCode,
                City = city
            };

            var result = await _userManager.CreateAsync(newUser, password);
            if (result.Succeeded)
            {
                return new AuthenticateResultModel
                {
                    IsSuccess = true,
                    Messages = new List<string> { "Registration complete!" }
                };
            }
            return new AuthenticateResultModel { Messages = new List<string> { "Registration failed" } };
        }

        public async Task<AuthenticateResultModel> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

            if (!result.Succeeded)
            {
                return new AuthenticateResultModel { Messages = new List<string> { "Login failed!" } };
            }

            var user = await _userManager.FindByNameAsync(username);
            var claims = await _userManager.GetClaimsAsync(user);

            var token = new JwtSecurityToken(
                audience: _configuration.GetValue<string>("JWTConfiguration:Audience"),
                issuer: _configuration.GetValue<string>("JWTConfiguration:Issuer"),
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(_configuration.GetValue<int>("JWTConfiguration:TokenExpirationInDays")),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SigninKey"))),
                    SecurityAlgorithms.HmacSha256)
                );

            var serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
            var serializedClaims = SerializeClaims(claims);

            return new AuthenticateResultModel
            {
                IsSuccess = true,
                Messages = new List<string> { serializedToken, serializedClaims }
            };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public string SerializeClaims(IList<Claim> claims)
        {

            StringBuilder sB = new();
            sB.Append("[");
            int counter = 0;

            foreach (var claim in claims)
            {
                counter++;
                sB.Append($"'{claim.Value}'");
                if (counter != claims.Count)
                {
                    sB.Append(',');
                }
            }

            sB.Append("]");

            return sB.ToString();
        }
    }
}
