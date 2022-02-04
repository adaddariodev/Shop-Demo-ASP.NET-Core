using Core.Responses;

namespace Core.Domain.Entities.CatalogueItemAggregate.Command.Delete
{
    public class DeleteItemCommandResponse : BaseResponse
    {
        public DeleteItemCommandResponse() :  base()
        {

        }

        public string Response { get; set; }
    }
}