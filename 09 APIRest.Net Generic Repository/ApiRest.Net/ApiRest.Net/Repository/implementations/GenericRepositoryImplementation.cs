using ApiRest.Net.Model;
using ApiRest.Net.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ApiRest.Net.Repository.implementations
{
    public class GenericRepositoryImplementation<T> : IGenericRepository<T> where T : BaseEntity
    {
        private SQLServerContext _context;
        private DbSet<T> _dataSet; 
        public GenericRepositoryImplementation(SQLServerContext context) //Implementação do acesso ao banco
        { 
            this._context = context;
           _dataSet = this._context.Set<T>();
        }
        public T Create(T item)
        {
            try
            {
                _dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void Delete(long id)
        {
            var result = _dataSet.FirstOrDefault<T>(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _dataSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Exists(int id)
        {
            return _dataSet.Any(p => p.Id== id);
        }

        public List<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T FindById(int id)
        {
            return _dataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;
            var result = _dataSet.SingleOrDefault(p => p.Id.Equals(item.Id));

            try
            {
                _dataSet.Update(result).CurrentValues.SetValues(item);
                _context.SaveChanges();

                return item;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
