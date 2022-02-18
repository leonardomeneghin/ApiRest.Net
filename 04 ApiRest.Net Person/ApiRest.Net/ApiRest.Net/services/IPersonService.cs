using ApiRest.Net.Model;
using System.Collections.Generic;

namespace ApiRest.Net.services.implementations
{
    public interface IPersonService
    {
        Person create(Person person);
        Person update(Person person);
        Person findByID(long person);
        List<Person> findAll();
        void delete(long id);
        
    }
}
