using ApiRest.Net.Data.Converter.Contract;
using ApiRest.Net.Data.Converter.VO;
using ApiRest.Net.Model;
using System.Collections.Generic;
using System.Linq;

namespace ApiRest.Net.Data.Converter.Implementations
{
    public class BookConverter : IParse<Book, BookVO>, IParse<BookVO, Book>
    {
        public Book Parse(BookVO item)
        {
            if (item == null) return null;
            var book = new Book()
            {
                Id = item.Id,
                Author = item.Author,
                Launch_date = item.Launch_date, 
                Price = item.Price,
                Title = item.Title
            };
            return book;
        }
        public BookVO Parse(Book item)
        {
            var bookVO = new BookVO
            {
                Id =item.Id,    
                Author = item.Author,
                Launch_date = item.Launch_date,
                Price = item.Price,
                Title = item.Title
            };
            return bookVO;
        }
        public List<Book> Parse(List<BookVO> itens)
        {
            return itens.Select(p =>  Parse(p)).ToList();
        }
        public List<BookVO> Parse(List<Book> itens)
        {
            return itens.Select(p => Parse(p)).ToList();
        }
    }
}
