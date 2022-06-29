using ApiRest.Net.Model;
using ApiRest.Net.Model.Context;
using ApiRest.Net.Repository.implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiRest.Net.Business.implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        public PersonBusinessImplementation(IPersonRepository repository) 
        {
            /*Pode-se criar as regras denegócio nesta etapa
             Permitindo ou não certos pontos do código*/
            _repository = repository;
        }
        public Person findByID(int id)
        {
            /*Pode-se criar as regras denegócio nesta etapa
             Permitindo ou não certos pontos do código*/
            return _repository.findByID(id);
        }
        public List<Person> findAll()
        {
            /*Pode-se criar as regras denegócio nesta etapa
             Permitindo ou não certos pontos do código*/
            return _repository.findAll();
        }

        public Person create(Person person)
        {
            /*Pode-se criar as regras denegócio nesta etapa
             Permitindo ou não certos pontos do código*/
            return _repository.create(person);
        }

        public void delete(long id)
        {
           _repository.delete(id);
        }


      


        public Person update(Person person)
        {
            return _repository.update(person);
         
        }
        /*Exists some pois virou uma classe interna do repository, usado
         apenas dentro do contexto de acesso do banco de dados*/
    }
}
