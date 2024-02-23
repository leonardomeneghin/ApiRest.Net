using ApiRest.Net.Data.Converter.Contract;
using ApiRest.Net.Data.Converter.Implementations;
using ApiRest.Net.Data.Converter.VO;
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
        private readonly PersonConverter _personConverter;


        public PersonBusinessImplementation(IGenericRepository<Person> repository) 
        {
            /*Pode-se criar as regras denegócio nesta etapa
             Permitindo ou não certos pontos do código*/
            _repository = repository;

           _personConverter = new PersonConverter();
        }
        public PersonVO FindById(int id)
        {
            /*Pode-se criar as regras de negócio nesta etapa
             Permitindo ou não certos pontos do código*/
            var entidade = _repository.FindById(id);
            return _personConverter.Parse(entidade);
        }
        public List<PersonVO> FindAll()
        {
            /*Pode-se criar as regras denegócio nesta etapa
             Permitindo ou não certos pontos do código*/
            var entities = _repository.FindAll();
            return _personConverter.Parse(entities);
        }

        public PersonVO Create(PersonVO person)
        {
            /*Pode-se criar as regras denegócio nesta etapa
             Permitindo ou não certos pontos do código*/
            var personConverted = _personConverter.Parse(person);
            var entidade = _repository.Create(personConverted);
            return _personConverter.Parse(entidade);
        }

        public void Delete(long id)
        {
           _repository.Delete(id);
        }


        public PersonVO Update(PersonVO person)
        {
            var personConverted = _personConverter.Parse(person);
            var entidade = _repository.Update(personConverted);
            return _personConverter.Parse(entidade);
         
        }
        /*Exists some pois virou uma classe interna do repository, usado
         apenas dentro do contexto de acesso do banco de dados*/
    }
}
