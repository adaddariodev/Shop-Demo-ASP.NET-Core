using Core.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Entities.User.Command.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("Maximum lenght 20 characters.");

            RuleFor(r => r.Surname)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("Maximum lenght 20 characters.");

            /* RuleFor(r => r)
                .MustAsync(IsUserUnique)
                .WithMessage("The same user already exists.");
            */
        }

        /*
        private async Task<bool> IsUserUnique(CreateUserCommand u, CancellationToken token)
        {
            return !await _userRepository.IsUserUnique(u.Name, u.Surname);
        }
        */
    }
}
