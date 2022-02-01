using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.FileService
{
    public interface IFileService
    {
        Task SaveFileAsync(IFormFile file);
        string GetMimeType(string fileExtension);
    }
}
