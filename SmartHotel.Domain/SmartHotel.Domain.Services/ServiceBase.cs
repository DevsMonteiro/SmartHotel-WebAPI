using SmartHotel.Domain.Interface.IRepositories;
using SmartHotel.Domain.Interface.IServicies;
using System;
using System.Collections.Generic;

namespace SmartHotel.Domain.Servicies
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this._repository = repository;
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}