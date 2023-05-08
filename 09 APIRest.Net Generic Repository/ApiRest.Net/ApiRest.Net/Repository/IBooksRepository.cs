using ApiRest.Net.Model;
using System.Collections.Generic;

namespace ApiRest.Net.Repository
{
    public interface IBooksRepository
    {
        Books createBook(Books book);
        Books updateBook(Books book);
        Books findById(int id);
        void deleteBook(long id);
        List<Books> findAll();
        bool Exists(int id);
    }

}
