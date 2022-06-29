using ApiRest.Net.Model.Context;
using System.Collections.Generic;

namespace ApiRest.Net.Repository.implementations
{
    public class BooksRepositoryImplementations : IBooksRepository
    {
        private SQLServerContext _context;

        public BooksRepositoryImplementations(SQLServerContext context) 
        {
            _context = context;
        }
        //TODO - IMplementar os métodos e adicionar no contexto, em seguida adicionar ao Business
        public Books findById(int id)
        {
            return 
        }
        public Books createBook(Books book)
        {
            throw new System.NotImplementedException();
        }

        public void deleteBook(long id)
        {
            throw new System.NotImplementedException();
        }

        public bool exists(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Books> findAll()
        {
            throw new System.NotImplementedException();
        }


        public Books updateBook(Books book)
        {
            throw new System.NotImplementedException();
        }
    }
}
