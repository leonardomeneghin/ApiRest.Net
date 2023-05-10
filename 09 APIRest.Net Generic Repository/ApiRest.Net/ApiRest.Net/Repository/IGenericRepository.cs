using ApiRest.Net.Model;
using System.Collections.Generic;

namespace ApiRest.Net.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        T FindById(int id);
        void Delete(long id);
        List<T> FindAll();
        bool Exists(int id);
    }
}
