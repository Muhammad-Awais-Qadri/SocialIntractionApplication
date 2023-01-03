using Microsoft.EntityFrameworkCore;
using SocialIntractionApplication.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialIntractionApplication.Repository.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> predicate) =>
            await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAll() =>
            await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetById(int id) =>
            await _dbContext.Set<TEntity>().FindAsync(id);

        public void Add(TEntity entity) =>
            _dbContext.Set<TEntity>().Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) =>
            _dbContext.Set<TEntity>().AddRange(entities);
        public void Remove(TEntity entity) =>
            _dbContext.Set<TEntity>().Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) =>
            _dbContext.Set<TEntity>().RemoveRange(entities);
    }
}
