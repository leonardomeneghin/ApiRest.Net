using ApiRest.Net.Model;
using System.Collections.Generic;

namespace ApiRest.Net.Repository.implementations
{
    public interface IPersonRepository
    {
        Person create(Person person);
        Person update(Person person);
        Person findByID(int person);
        List<Person> findAll();
        void delete(long id);
        bool Exists(int id);


    }
}
