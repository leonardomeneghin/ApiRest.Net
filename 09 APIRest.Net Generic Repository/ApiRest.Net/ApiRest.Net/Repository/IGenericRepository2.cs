using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ApiRest.Net.Repository
{
    public interface IGenericRepository2<T> where T : BaseEntity
    {
        //Generic precisa corresponder ao termo T do genérico
        public T Create(T item); //Será implementado logo menos na Repository
        public T Update(T item);
        public void Delete(int delete);
        public List<T> FindAll();
        public T FindById(int id);  
    }
}
