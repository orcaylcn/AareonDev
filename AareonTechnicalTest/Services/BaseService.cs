using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Repositories;

namespace AareonTechnicalTest.Services
{
    public class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey>
        where TEntity : class, IEntity, new()
    {
        private readonly IEntityRepository<TEntity, TKey> _repository;

        public BaseService(IEntityRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public virtual Task<TEntity> Get(TKey id) =>
            _repository.Get(id);

        public virtual Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null) =>
            _repository.GetAll(filter);

        public virtual async Task Add(TEntity entity)
        {
            await _repository.Add(entity);
        }

        public virtual async Task Update(TKey id, TEntity entity)
        {
            await _repository.Update(id, entity);
        }

        public virtual async Task Delete(TKey id)
        {
            await _repository.Delete(id);
        }

        public virtual async Task Delete(TEntity entity)
        {
            await _repository.Delete(entity);
        }
    }
}
