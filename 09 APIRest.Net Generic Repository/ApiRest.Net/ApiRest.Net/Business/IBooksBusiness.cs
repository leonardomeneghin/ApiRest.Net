using ApiRest.Net.Model;
using System.Collections.Generic;


namespace ApiRest.Net.Business
{
     public interface IBooksBusiness
     {
      //Devemos lembrar referenciar as classes
      Books create(Books book);
      Books update(Books book);
      Books findByID(int book);
      List<Books> findAll();
      void delete(int id);
      bool exists(int id);
     }
}
