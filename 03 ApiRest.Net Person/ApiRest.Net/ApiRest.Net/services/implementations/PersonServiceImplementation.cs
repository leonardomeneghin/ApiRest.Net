using ApiRest.Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiRest.Net.services.implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count=0;

        public Person create(Person person)
        {
            //Aqui ocorre o acesso à base de dados.
            return person;
        }

        public void delete(long id)
        {
            
        }

        public List<Person> findAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++) { //Mocking de persons
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                id = IncrementAndGet() +i,
                first_name = "Some name" +i,
                last_name = "Some LastName" +i,
                address = "Some ADDRESS"+i,
                gender = "Gender"+i
            };
        }

        public Person findByID(long person)
        {
            return new Person
            { 
                id = IncrementAndGet(),
                first_name = "Leandro",
                last_name = "Costa",
                address = "Uberlandia - Minas Gerais - Brasil",
                gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person update(Person person)
        {
            return person;
        }
    }
}
