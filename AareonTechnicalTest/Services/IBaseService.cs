using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.Services
{
    public interface IBaseService<TEntity, in TKey>
        where TEntity : class, IEntity, new()
    {
        Task<TEntity> Get(TKey id);

        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);

        Task Add(TEntity entity);

        Task Update(TKey id, TEntity entity);

        Task Delete(TKey id);

        Task Delete(TEntity entity);
    }
}
