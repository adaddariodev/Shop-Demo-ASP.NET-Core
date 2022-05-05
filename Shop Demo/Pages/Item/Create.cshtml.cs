using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Core.Domain.Entities.CatalogueItemAggregate;
using Core.Domain.Entities.CatalogueItemAggregate.Command;
using Core.Domain.Entities.CatalogueItemAggregate.Command.Create;
using Core.Services.FileService;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shop_Demo.Pages.Item
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMediator _mediator;

        public CreateModel(IWebHostEnvironment hostingEnvironment, IMediator mediator)
        {
            _hostingEnvironment = hostingEnvironment;
            _mediator = mediator;
        }

        [BindProperty]
        [Required]
        public IFormFile FileUploaded { get; set; }

        [BindProperty]
        public CatalogueItemDTO Item { get; set; }

        public string Response { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToPage("../Index", "You need to be logged in first!");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            if (FileUploaded != null)
            {
                if (FileUploaded.Length > 0)
                {
                    //Save the item record into DB

                    //var fileExtension = Path.GetExtension(FileUploaded.FileName);

                    var path = Path.Combine(/*_hostingEnvironment.WebRootPath, */"Uploads", HttpContext.User.Identity.Name, FileUploaded.FileName);

                    var response = await _mediator.Send(new CreateItemCommand(Item.Name, Item.Description, Item.Price, path));
                    
                    if(!response.Success)
                    {
                        Response = response.Message;
                        return Page();
                    }else
                    {
                        //Save file in directory
                        await SaveUploadedFileAsync();
                    }
                    
                }

                return RedirectToPage("../Index");
            }

            return Page();
        }

        private async Task SaveUploadedFileAsync()
        {
            var fileName = Path.GetFileName(FileUploaded.FileName);

            string owner = HttpContext.User.Identity.Name;

            string path = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", owner);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await FileUploaded.CopyToAsync(stream);
            }
        }

        private string GetMimeType(string fileExtension)
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
    }
}