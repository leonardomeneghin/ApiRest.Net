using ApiRest.Net.Model;
using System.Collections.Generic;


namespace ApiRest.Net.Business
{
     public interface IBookBusiness
     {
      //Devemos lembrar referenciar as classes
      Book create(Book book);
      Book update(Book book);
      Book findByID(int book);
      List<Book> findAll();
      void delete(int id);
      bool exists(int id);
     }
}
