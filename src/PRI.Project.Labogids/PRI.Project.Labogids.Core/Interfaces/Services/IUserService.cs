using PRI.Project.Labogids.Core.Services.Models;
using System;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthenticateResultModel> Register(string firstname, string lastname, string username, string email, DateTime dateOfBirth, 
            string address, int postalCode, string city, string password);

        Task<AuthenticateResultModel> Login(string username, string password);

        Task Logout();
    }
}
