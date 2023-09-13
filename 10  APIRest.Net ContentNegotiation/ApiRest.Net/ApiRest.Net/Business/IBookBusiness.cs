using ApiRest.Net.Data.Converter.VO;
using ApiRest.Net.Model;
using System.Collections.Generic;


namespace ApiRest.Net.Business
{
     public interface IBookBusiness
     {
      //Devemos lembrar referenciar as classes
      BookVO create(BookVO book);
      BookVO update(BookVO book);
      BookVO findByID(int id);
      List<BookVO> findAll();
      void delete(int id);
      bool exists(int id);
     }
}
