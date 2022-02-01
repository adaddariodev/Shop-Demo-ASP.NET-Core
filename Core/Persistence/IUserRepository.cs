using Core.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence
{
    public interface IUserRepository : IAsyncRepository<Userx>
    {
        Task<bool> IsUserUnique(string name, string surname);
        Task<Userx> GetByName(string name);
    }
}
