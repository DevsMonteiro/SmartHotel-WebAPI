using Microsoft.EntityFrameworkCore;
using SmartHotel.Query.Data.Context;
using SmartHotel.Query.Domain.Interface.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Query.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly QueryDataContext _context;

        public RepositoryBase(QueryDataContext context)
        {
            this._context = context;
        }

        public void Add(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}