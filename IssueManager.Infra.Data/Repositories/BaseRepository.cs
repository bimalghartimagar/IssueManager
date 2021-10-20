using System.Collections.Generic;
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

        public IEnumerable<T> GetItems()
        {
            return _dbContext.Set<T>();
        }

        public T GetItem(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T CreateItem(T item)
        {
            _dbContext.Set<T>().Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public T UpdateItem(T item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return item;
        }
        public void DeleteItem(int id)
        {
            var itemToDelete = _dbContext.Set<T>().Find(id);
            if (itemToDelete is not null)
            {
                _dbContext.Set<T>().Remove(itemToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}