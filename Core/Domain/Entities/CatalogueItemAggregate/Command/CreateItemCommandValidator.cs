using Core.Persistence;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Entities.CatalogueItemAggregate.Command
{
    internal class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        private readonly ICatalogueItemRepository _catalogueItemRepository;

        public CreateItemCommandValidator(ICatalogueItemRepository catalogueItemRepository)
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
        }
    }
}