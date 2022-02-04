using Core.Responses;

namespace Core.Domain.Entities.CatalogueItemAggregate.Command.Update
{
    public class UpdateItemCommandResponse : BaseResponse
    {
        public UpdateItemCommandResponse() : base()
        {

        }

        public CatalogueItemDTO Item { get; set; }
    }
}