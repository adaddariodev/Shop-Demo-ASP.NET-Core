using Core.Domain.Entities.User;
using Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<Userx>, IUserRepository
    {
        public UserRepository(MyDbContext myDbContext) : base(myDbContext)
        {
        }

        public async Task<Userx> GetByName(string name)
        {
            var user = _myDbContext.Users.FirstOrDefault(x => x.Name == name);
            return user;
        }

        public Task<bool> IsUserUnique(string name, string surname)
        {
            throw new NotImplementedException();
        }
    }
}
