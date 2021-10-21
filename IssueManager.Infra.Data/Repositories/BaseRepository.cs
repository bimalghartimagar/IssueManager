using System.Collections.Generic;
using System.Threading.Tasks;
using IssueManager.Domain.Interfaces;
using IssueManager.Domain.Model;
using IssueManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace IssueManager.Infra.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {

        readonly private IssueManagerDbContext _dbContext;
        public BaseRepository(IssueManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetItemsAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> CreateItemAsync(T item)
        {
            await _dbContext.Set<T>().AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<T> UpdateItemAsync(T item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return item;
        }
        public async Task DeleteItemAsync(int id)
        {
            var itemToDelete = await _dbContext.Set<T>().FindAsync(id);
            if (itemToDelete is not null)
            {
                _dbContext.Set<T>().Remove(itemToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}