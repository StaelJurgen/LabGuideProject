using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Interfaces.Services
{
    public interface IImageService
    {
        Task<string> AddOrUpdateImageAsync<T>(IFormFile image, string fileName = "");
        public string GetUrl<T>(string fileName);
    }
}
