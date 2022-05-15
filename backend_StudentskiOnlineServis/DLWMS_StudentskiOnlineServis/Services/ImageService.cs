using DLWMS_StudentskiOnlineServis.Services.Responses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Services
{
    public interface IImageService
    {
        ImageUploadResponse UploadImage(IFormFile file);
    }
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ImageService(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }

        public ImageUploadResponse UploadImage(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            if (file.Length > 0)
            {
                var path = Path.Combine(webHostEnvironment.WebRootPath, fileName);
                var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);
                using (var stream = System.IO.File.Create(path))
                {
                    memoryStream.Position = 0;
                    memoryStream.CopyTo(stream);
                }
            }
            var request = this.httpContextAccessor.HttpContext.Request;

            return new ImageUploadResponse
            {
                ImageUrl = $"{request.Scheme}://{request.Host}{request.PathBase}/{fileName}"
            };
        }
    }
}
