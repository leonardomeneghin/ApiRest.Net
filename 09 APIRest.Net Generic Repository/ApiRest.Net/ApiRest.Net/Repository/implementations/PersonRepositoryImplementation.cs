using ApiRest.Net.Business.implementations;
using ApiRest.Net.Model;
using ApiRest.Net.Model.Context;
using ApiRest.Net.Repository.implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiRest.Net.services.implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private SQLServerContext _context;

        public PersonRepositoryImplementation(SQLServerContext context) 
        {
            _context = context;
        }
        public Person findByID(int id)
        {
            return _context.Persons.SingleOrDefault(p => p.id.Equals(id));
        }
        public List<Person> findAll()
        {

            return _context.Persons.ToList();
        }

        public Person create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }

        public void delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


      


        public Person update(Person person)
        {
            if (!Exists(person.id)) return null;
            var result = _context.Persons.SingleOrDefault(p => p.id.Equals(person.id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return person;
        }

        public bool Exists(int id)
        {
            return _context.Persons.Any(p => p.id.Equals(id));
        }
    }
}
