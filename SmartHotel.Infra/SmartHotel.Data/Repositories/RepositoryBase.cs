using Microsoft.EntityFrameworkCore;
using SmartHotel.Data.Context;
using SmartHotel.Domain.Interface.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        public RepositoryBase(DataContext context)
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
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}