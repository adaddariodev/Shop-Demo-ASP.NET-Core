using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.User.Command.CreateUser
{
    public class CreateUserCommandResponse : BaseResponse
    {
        public CreateUserCommandResponse()
        {

        }

        public UserDTO User { get; set; }
    }
}
