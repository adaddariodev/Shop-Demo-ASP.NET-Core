using Core.Domain.Entities.CatalogueItemAggregate;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.CatalogueItemAggregate.Command
{
    public class CreateItemCommandResponse : BaseResponse
    {
        public CreateItemCommandResponse()
        {

        }

        public CatalogueItemDTO Item { get; set; }
    }
}
