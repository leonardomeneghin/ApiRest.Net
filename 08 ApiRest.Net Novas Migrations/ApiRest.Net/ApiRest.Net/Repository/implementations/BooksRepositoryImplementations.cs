using ApiRest.Net.Model;
using ApiRest.Net.Model.Context;
using System.Collections.Generic;
using System.Linq;
using System;
using static ApiRest.Net.Repository.IBooksRepository;
namespace ApiRest.Net.Repository.implementations
{
    public class BooksRepositoryImplementations : IBooksRepository
    {
        private SQLServerContext _context;

        public BooksRepositoryImplementations(SQLServerContext context) 
        {
            _context = context;
        }
       
        public Books findById(int id)
        {

            return _context.Books.SingleOrDefault(book => book.Id.Equals(id));
        }
        public Books createBook(Books book)
        {
            try
            {
                _context.Add(book); //Adiciona o objeto
                _context.SaveChanges(); //Persiste os dados
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return book;
        }

        public void deleteBook(long id)
        {
            var result = _context.Books.FirstOrDefault(book => book.Id.Equals(id)); //No contexto do banco, encontrar o primeiro ou nenhum livro cujo id do objeto 
                                                                                    //seja igual ao valor inserido.
            if (result != null)
            {

                try
                {
                    _context.Remove(id);
                    _context.SaveChanges();
                }
                catch (System.Exception ex)
                {

                    throw ex;
                }
                return;
            }

        }

        public bool Exists(int id)
        {
            var resultado = _context.Books.SingleOrDefault(book => book.Id.Equals(id));
            return resultado != null ? true : false;
        }

        public List<Books> findAll()
        {
            return _context.Books.ToList(); //Retorna todos os objetos listados
        }


        public Books updateBook(Books book)
        {
            var resultado = _context.Books.SingleOrDefault(p => p.Id.Equals(book.Id));
            if (resultado != null)
            {
                try
                {
                    _context.Entry(resultado).CurrentValues.SetValues(book); /* Na "entrada" do resultado, com o valor atual do resultado,
                                                                                 modifica os valores do objeto da entrada com os valores do objeto que foi passado*/
                    _context.SaveChanges();
                    
                }
                catch (System.Exception ex)
                {

                    throw ex;
                }
                
            }
            return book;

        }
    }
}
