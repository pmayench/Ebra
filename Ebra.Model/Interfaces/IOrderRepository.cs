using Ebra.Models.Models;
using System.Collections.Generic;

namespace Ebra.Models.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Insert(Order item);
        void Update(Order item);
        void Delete(int id);
        void DeleteAll();
        //void Save();
        void AddRange(List<Order> range);
    }

    public interface IGenericRepository<T> where T : class, new()
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T item);
        void Update(T item);
        void Delete(int id);
        void DeleteAll();
        //void Save();
        void AddRange(List<T> range);
    }
}
