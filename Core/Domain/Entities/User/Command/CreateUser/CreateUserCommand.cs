using AutoMapper;
using Core.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Entities.User.Command.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public CreateUserCommand(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; }
        public string Surname { get; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var createUserCommandResponse = new CreateUserCommandResponse();

            var validator = new CreateUserCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createUserCommandResponse.Success = false;
                createUserCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    createUserCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createUserCommandResponse.Success)
            {
                var user = new Userx(request.Name, request.Surname);
                user = await _userRepository.AddAsync(user);
                createUserCommandResponse.User = _mapper.Map<UserDTO>(user);
            }

            return createUserCommandResponse;
        }
    }
}
