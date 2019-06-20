using System.Collections.Generic;

namespace Common.Services.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetList();
        T Get(int? id); 
        void Create(T item); 
        void Edit(T item);
        void Delete( T item ); 

    }
}
