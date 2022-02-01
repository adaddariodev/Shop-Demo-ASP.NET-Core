using Core.Domain.Entities.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.User
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surnmame { get; set; }
        public List<CatalogueItemDTO> CatalogueItem { get; set; }
    }
}
