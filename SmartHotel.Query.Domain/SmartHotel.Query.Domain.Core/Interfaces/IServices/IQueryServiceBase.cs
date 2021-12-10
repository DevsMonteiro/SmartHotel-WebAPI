using System;
using System.Collections.Generic;

namespace SmartHotel.Query.Domain.Interface.IServicies
{
    public interface IQueryServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(Guid id);

    }
}