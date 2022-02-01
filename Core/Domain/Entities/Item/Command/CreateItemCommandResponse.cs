using Core.Domain.Entities.Item;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.User.Command.CreateUser
{
    public class CreateItemCommandResponse : BaseResponse
    {
        public CreateItemCommandResponse()
        {

        }

        public CatalogueItemDTO Item { get; set; }
    }
}
