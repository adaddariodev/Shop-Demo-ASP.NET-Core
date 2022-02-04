using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.CatalogueItemAggregate.Command.Create
{
    public class CreateItemCommandResponse : BaseResponse
    {
        public CreateItemCommandResponse() : base()
        {

        }

        public CatalogueItemDTO Item { get; set; }
    }
}
