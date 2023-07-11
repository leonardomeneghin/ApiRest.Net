
using ApiRest.Net.Data.Converter.Implementations;
using ApiRest.Net.Data.Converter.VO;
using ApiRest.Net.Model;
using ApiRest.Net.Repository;
using System.Collections.Generic;
using System.Net;

namespace ApiRest.Net.Business.implementations
{
    public class BooksBusinessImplementation : IBookBusiness
    {
        private IGenericRepository<Book> _repository;
        private BookConverter _bookConverter;
        public BooksBusinessImplementation(IGenericRepository<Book> repository) 
        {
            //Método construtor, chamado sempre que o objeto é instanciado com o operador new
            _repository = repository; //Atributo privado à classe precisa receber o objeto passado pelo construtor.
            _bookConverter = new BookConverter();
        }

        public BookVO create(BookVO bookVO)
        {
            try
            {
                var bookConverted = _bookConverter.Parse(bookVO);
                var book = _repository.Create(bookConverted);
                return _bookConverter.Parse(book);
                
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void delete(int id)
        {
            _repository.Delete(id); 
        }

        public bool exists(int id)
        {
            return _repository.Exists(id); 
        }

        public List<BookVO> findAll()
        {
            var books = _repository.FindAll();
                 
            return _bookConverter.Parse(books);
        }

        public BookVO findByID(int id)
        {
            var book = _bookConverter.Parse(_repository.FindById(id));
            return book;
        }

        public BookVO update(BookVO book)
        {
            var bookConverted = _bookConverter.Parse(book);
            var bookEntidade =_repository.Update(bookConverted);
            return _bookConverter.Parse(bookEntidade);

        }
    }
}
