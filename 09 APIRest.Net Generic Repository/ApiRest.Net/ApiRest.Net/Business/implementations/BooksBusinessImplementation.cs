
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

        public Book create(BookVO bookVO)
        {
            var book = _bookConverter.Parse(bookVO);
            return _repository.Create(book);
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
            return _bookConverter.Parse(_repository.FindAll());
        }

        public Book findByID(int id)
        {
            return _repository.FindById(id);
        }

        public BookVO update(Book book)
        {
            return _bookConverter.Parse(_repository.Update(book));
;        }
    }
}
