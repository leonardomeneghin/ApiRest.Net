using ApiRest.Net.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using ApiRest.Net.Model;

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
            try
            {
                _dbSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            var result = _dbSet.FirstOrDefault<T>(p => p.Id.Equals(id));
            try
            {
                if (result == null) return ;
                _dbSet.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T> FindAll()
        {
           return _dbSet.ToList();
        }

        public T FindById(int id)
        {
            try
            {
                var result = _dbSet.FirstOrDefault(p => p.Id.Equals(id));
                return result;
            }
            catch (Exception)
            {

                throw;
            }
;
        }

        public T Update(T item)
        {
            var result = _dbSet.FirstOrDefault(p => p.Id.Equals(item.Id));
            if (result is null) return null;
            try
            {
                _dbSet.Update(result);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
