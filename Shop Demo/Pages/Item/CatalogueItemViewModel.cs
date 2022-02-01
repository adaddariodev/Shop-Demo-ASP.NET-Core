using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Shop_Demo.Pages.Item
{
    public class CatalogueItemViewModel
    {
        [Required]
        [BindProperty]
        [Display(Name = "Item Name")]

        public string Name { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "Description")]

        public string Description { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "Price")]

        public int Price { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "Upload Image")]
        public IFormFile FileUploaded { get; set; }
    }
}