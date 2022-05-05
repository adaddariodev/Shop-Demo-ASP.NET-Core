using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.CatalogueItemAggregate
{
    public class CatalogueItemDTO
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Created by")]
        public string User { get; set; }
    }
}
