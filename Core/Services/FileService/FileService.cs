using Core.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Core.Services.FileService
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _environment;
        private readonly HttpContext _httpContext;

        public FileService(IHostingEnvironment Environment, HttpContext httpContext)
        {
            _environment = Environment;
            _httpContext = httpContext;
        }


        public string GetMimeType(string fileExtension)
        {
            var contentType = "";

            switch (fileExtension)
            {
                case ".png":
                    contentType = "image/png";
                    break;
                case ".jpg":
                    contentType = "image/jpeg";
                    break;
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".gif":
                    contentType = "image/gif";
                    break;
                case ".pdf":
                    contentType = "application/pdf";
                    break;
                case ".doc":
                    contentType = "application/msword";
                    break;
                case ".docx":
                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case ".txt":
                    contentType = "text/plain";
                    break;
                case ".mp3":
                    contentType = "audio/mpeg";
                    break;
                case ".mp4":
                    contentType = "video/mp4";
                    break;
                case ".mpeg":
                    contentType = "video/mpeg";
                    break;
                default:
                    contentType = "application/octet";
                    break;
            }

            return contentType;
        }


        public async Task SaveFileAsync(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);

            //var fileExtension = Path.GetExtension(fileName);
            //var contentType = GetMimeType(fileExtension);

            string owner = _httpContext.User.Identity.Name;

            string path = Path.Combine(_environment.WebRootPath, "Uploads", owner);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
                        
        }
    }
}
