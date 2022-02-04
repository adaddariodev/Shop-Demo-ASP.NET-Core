using Core.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Entities.CatalogueItemAggregate.Command.Delete
{
    public class DeleteItemCommand : IRequest<DeleteItemCommandResponse>
    {
        public DeleteItemCommand(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }

    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, DeleteItemCommandResponse>
    {
        private readonly ICatalogueItemRepository _catalogueItemRepository;

        public DeleteItemCommandHandler(ICatalogueItemRepository catalogueItemRepository)
        {
            _catalogueItemRepository = catalogueItemRepository;
        }

        public async Task<DeleteItemCommandResponse> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var deleteItemCommandResponse = new DeleteItemCommandResponse();

            var validator = new DeleteItemCommandValidator(_catalogueItemRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                deleteItemCommandResponse.Success = false;
                deleteItemCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    deleteItemCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (deleteItemCommandResponse.Success)
            {
                var prodotto = await _catalogueItemRepository.GetByIdAsync(request.Id);
                await _catalogueItemRepository.DeleteAsync(prodotto);
            }

            return deleteItemCommandResponse;
        }
    }
}
