using System;
using System.Collections.Generic;

namespace SmartHotel.Domain.Interface.IRepositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(Guid id);
    }
}