
using ApiRest.Net.Model;
using ApiRest.Net.Repository;
using System.Collections.Generic;
using System.Net;

namespace ApiRest.Net.Business.implementations
{
    public class BooksBusinessImplementation : IBookBusiness
    {
        private IGenericRepository<Book> _repository;
        public BooksBusinessImplementation(IGenericRepository<Book> repository) 
        {
            //Método construtor, chamado sempre que o objeto é instanciado com o operador new
            _repository = repository; //Atributo privado à classe precisa receber o objeto passado pelo construtor.
        }

        public Book create(Book book)
        {
            return _repository.Create(book);
        }

        public void delete(int id)
        {
            _repository.Delete(id); //Lembrar de retornar um noContent da classe AspNetCore.Http
        }

        public bool exists(int id)
        {
            return _repository.Exists(id); 
        }

        public List<Book> findAll()
        {
            return _repository.FindAll();
        }

        public Book findByID(int id)
        {
            return _repository.FindById(id);
        }

        public Book update(Book book)
        {
            return _repository.Update(book);
;        }
    }
}
