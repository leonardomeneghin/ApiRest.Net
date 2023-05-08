using ApiRest.Net.Model;
using System.Collections.Generic;

namespace ApiRest.Net.Business.implementations
{
    public interface IPersonBusiness
    {
        Person create(Person person);
        Person update(Person person);
        Person findByID(int person);
        List<Person> findAll();
        void delete(long id);
        
    }
}
