using ApiRest.Net.Model;
using System.Collections.Generic;

namespace ApiRest.Net.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        T findById(int id);
        void delete(long id);
        List<T> findAll();
        bool Exists(int id);
    }
}
