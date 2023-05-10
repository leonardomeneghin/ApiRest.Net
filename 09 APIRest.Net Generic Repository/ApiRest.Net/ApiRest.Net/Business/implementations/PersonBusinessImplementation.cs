using ApiRest.Net.Model;
using ApiRest.Net.Model.Context;
using ApiRest.Net.Repository;
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
        private readonly IGenericRepository<Person> _repository;

        public PersonBusinessImplementation(IGenericRepository<Person> repository) 
        {
            /*Pode-se criar as regras denegócio nesta etapa
             Permitindo ou não certos pontos do código*/
            _repository = repository;
        }
        public Person FindById(int id)
        {
            /*Pode-se criar as regras de negócio nesta etapa
             Permitindo ou não certos pontos do código*/
            return _repository.FindById(id);
        }
        public List<Person> FindAll()
        {
            /*Pode-se criar as regras denegócio nesta etapa
             Permitindo ou não certos pontos do código*/
            return _repository.FindAll();
        }

        public Person Create(Person person)
        {
            /*Pode-se criar as regras denegócio nesta etapa
             Permitindo ou não certos pontos do código*/
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
           _repository.Delete(id);
        }


      


        public Person Update(Person person)
        {
            return _repository.Update(person);
         
        }
        /*Exists some pois virou uma classe interna do repository, usado
         apenas dentro do contexto de acesso do banco de dados*/
    }
}
