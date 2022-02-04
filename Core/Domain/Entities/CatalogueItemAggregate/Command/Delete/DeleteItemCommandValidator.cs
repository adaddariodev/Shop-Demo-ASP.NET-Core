using Core.Domain.Entities.CatalogueItemAggregate.Command.Create;
using Core.Persistence;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Entities.CatalogueItemAggregate.Command.Delete
{
    public class DeleteItemCommandValidator : AbstractValidator<DeleteItemCommand>
    {
        private readonly ICatalogueItemRepository _catalogueItemRepository;

        public DeleteItemCommandValidator(ICatalogueItemRepository catalogueItemRepository)
        {
            _catalogueItemRepository = catalogueItemRepository;

            RuleFor(r => r)
                .MustAsync(ItemExist)
                .WithMessage("The Item you are trying to delete, doesnt exist.");
        }

        private async Task<bool> ItemExist(DeleteItemCommand i, CancellationToken token)
        {
            return !(await _catalogueItemRepository.ItemExist(i.Id));
        }
    }
}