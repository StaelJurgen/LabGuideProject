using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using PRI.Project.Labogids.Core.Interfaces.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ImageService(IHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _hostEnvironment = hostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUrl<T>(string fileName)
        {
            var scheme = _httpContextAccessor.HttpContext.Request.Scheme;
            var host = _httpContextAccessor.HttpContext.Request.Host.Value;
            var imagesFolder = $"images/{typeof(T).Name.ToLower()}";
            var fullUrl = $"{scheme}://{host}/{imagesFolder}/{fileName}";
            return fullUrl;
        }

        public async Task<string> AddOrUpdateImageAsync<T>(IFormFile image, string fileName = "")
        {
            //check for update(if filename == "", => add)
            if (fileName == "")
            {
                //generate name for new filename
                fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            }

            //generate path on disk (D:/....wwwroot/images/<entity>)
            var pathOnDisk = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot",
                "images", typeof(T).Name.ToLower());

            //check if directory exists
            if (!Directory.Exists(pathOnDisk))
            {
                Directory.CreateDirectory(pathOnDisk);
            }


            //store file
            var completePathWithFilename = Path.Combine(pathOnDisk, fileName);
            using (FileStream fileStream = new(completePathWithFilename, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            //return filename
            return fileName;
        }
    }
}
