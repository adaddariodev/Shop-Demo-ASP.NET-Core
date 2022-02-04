using Core.Persistence;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Entities.CatalogueItemAggregate.Command.Update
{
    public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
    {
        private ICatalogueItemRepository _catalogueItemRepository;

            public UpdateItemCommandValidator(ICatalogueItemRepository catalogueItemRepository)
            {
                _catalogueItemRepository = catalogueItemRepository;


                RuleFor(r => r.Name)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(20).WithMessage("Maximum lenght 20 characters.");

                RuleFor(r => r.Description)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(100).WithMessage("Maximum lenght 100 characters.");

                RuleFor(r => r.ImagePath)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(100).WithMessage("Maximum lenght 100 characters.");

                RuleFor(r => r.Price)
                    .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} needs to be grater than 0.");

                RuleFor(r => r)
                .MustAsync(ItemExist)
                .WithMessage("The Item you are trying to delete, doesnt exist.");
            }

            private async Task<bool> ItemExist(UpdateItemCommand i, CancellationToken token)
            {
                return !(await _catalogueItemRepository.ItemExist(i.Id));
            }
        }
    }
}