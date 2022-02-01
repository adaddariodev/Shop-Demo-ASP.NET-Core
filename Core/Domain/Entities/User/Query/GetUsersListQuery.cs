using AutoMapper;
using Core.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Entities.User.Query
{
    public class GetUsersListQuery : IRequest<List<UserDTO>>
    {
    }

    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<UserDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUsersListQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<UserDTO>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.ListAllAsync();

            if (users is null)
                throw new ArgumentException();

            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}
