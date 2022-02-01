using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Entities.Item;
using Core.Services.FileService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shop_Demo.Pages.Item
{
    public class CreateModel : PageModel
    {
        private readonly IFileService _fileService;

        public CreateModel(IFileService fileService)
        {
            _fileService = fileService;
        }

        public CatalogueItemViewModel Item { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            if (Item.FileUploaded != null)
            {
                if (Item.FileUploaded.Length > 0)
                {
                    await _fileService.SaveFileAsync(Item.FileUploaded);
                }

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
