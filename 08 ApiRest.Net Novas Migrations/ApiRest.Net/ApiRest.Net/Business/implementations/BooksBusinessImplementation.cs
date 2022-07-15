
using ApiRest.Net.Model;
using ApiRest.Net.Repository;
using System.Collections.Generic;
using System.Net;

namespace ApiRest.Net.Business.implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        private IBooksRepository _repository;
        public BooksBusinessImplementation(IBooksRepository _repository) 
        { 
            //Método construtor, chamado sempre que o objeto é instanciado com o operador new

        }

        public Books create(Books book)
        {
            return _repository.createBook(book);
        }

        public void delete(int id)
        {
            _repository.deleteBook(id); //Lembrar de retornar um noContent da classe AspNetCore.Http
        }

        public bool exists(int id)
        {
            return _repository.Exists(id); 
        }

        public List<Books> findAll()
        {
            return _repository.findAll();
        }

        public Books findByID(int id)
        {
            return _repository.findById(id);
        }

        public Books update(Books book)
        {
            return _repository.updateBook(book);
;        }
    }
}
