using ApiRest.Net.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiRest.Net.Repository.implementations
{
    public class GenericRepositoryImplementation2<T> : IGenericRepository2<T> where T : BaseEntity
    {
        private SQLServerContext _context;
        private DbSet<T> _dbSet;
        public GenericRepositoryImplementation2(SQLServerContext context)
        {
            this._context = context;
            _dbSet = this._context.Set<T>();
        }
        public T Create(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int delete)
        {
            throw new System.NotImplementedException();
        }

        public List<T> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public T Update(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
