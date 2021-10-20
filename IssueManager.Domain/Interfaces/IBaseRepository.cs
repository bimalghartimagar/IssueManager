using System.Collections.Generic;
using IssueManager.Domain.Model;

namespace IssueManager.Domain.Interfaces{
    public interface IBaseRepository<T>{
        IEnumerable<T> GetItems();
        T GetItem(int id);
        T CreateItem(T ticket);
        T UpdateItem(T ticket);
        void DeleteItem(int id);
    }
}