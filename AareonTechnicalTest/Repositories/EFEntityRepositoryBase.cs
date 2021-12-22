using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AareonTechnicalTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AareonTechnicalTest.Repositories
{
    public class EFEntityRepositoryBase<TEntity, TKey> : IEntityRepository<TEntity, TKey>
        where TEntity : class, IEntity, new()
    {
        private readonly ApplicationContext _dbContext;

        public EFEntityRepositoryBase(ApplicationContext context)
        {
            _dbContext = context;
        }

        public virtual async Task<TEntity> Get(TKey id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ?
                await _dbContext.Set<TEntity>().ToListAsync() :
                await _dbContext.Set<TEntity>().Where(filter).ToListAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Update(TKey id, TEntity entity)
        {
            var existingItem = await Get(id);
            if (existingItem == null)
            {
                throw new ArgumentException("Invalid id: " + id);
            }

            //This doesn't work because the Id field is readonly because of the Key attribute
            //And this method will be overriden
            _dbContext.Entry(existingItem).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Delete(TKey id)
        {
            var entity = await Get(id);
            if (entity == null)
            {
                throw new ArgumentException("Invalid id: " + id);
            }

            await Delete(entity);
        }

        public virtual async Task Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
