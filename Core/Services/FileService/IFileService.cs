using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Core.Services.FileService
{
    public interface IFileService
    {
        Task SaveFileAsync(IFormFile file);
        Task<string> GetMimeType(string fileExtension);
    }
}
