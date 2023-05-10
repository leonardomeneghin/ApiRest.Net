using ApiRest.Net.Model;
using ApiRest.Net.Repository;
using System.Collections.Generic;

namespace ApiRest.Net.Business.implementations
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person Update(Person person);
        Person FindById(int person);
        List<Person> FindAll();
        void Delete(long id);
        
    }
}
