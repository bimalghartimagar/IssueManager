using System.Collections.Generic;
using System.Threading.Tasks;
using IssueManager.Domain.Model;

namespace IssueManager.Domain.Interfaces{
    public interface IBaseRepository<T>{
        Task<IEnumerable<T>> GetItemsAsync();
        Task<T> GetItemAsync(int id);
        Task<T> CreateItemAsync(T ticket);
        Task<T> UpdateItemAsync(T ticket);
        Task DeleteItemAsync(int id);
    }
}