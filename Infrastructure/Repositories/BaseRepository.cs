using Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly MyDbContext _myDbContext;

        public BaseRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _myDbContext.Set<T>().AddAsync(entity);
            await _myDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _myDbContext.Set<T>().Remove(entity);
            await _myDbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _myDbContext.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> ListAllAsync()
        {
            return await _myDbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _myDbContext.Entry(entity).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();
        }
    }
}
