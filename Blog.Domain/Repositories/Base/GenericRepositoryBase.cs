using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Domain.Contexts;
using Blog.Domain.Contexts.Interfaces;
using Blog.Domain.Entities.Base;
using Blog.Domain.Repositories.Interfaces;

namespace Blog.Domain.Repositories.Base
{
    public abstract class GenericRepositoryBase<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected GenericRepositoryBase(BlogDbContext dbContext)
        {
            BlogDbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public IDbSet<TEntity> DbSet { get; }
        public IDbContext BlogDbContext { get; }
        public virtual IQueryable<TEntity> NotCachedQueryable => DbSet.AsNoTracking();

        public virtual async Task<IEnumerable<TEntity>> GetItemsAsync()
        {
            return await NotCachedQueryable.ToListAsync();
        }

        public virtual async Task AddAsync(TEntity item)
        {
            DbSet.Add(item);
            await BlogDbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity item)
        {
            BlogDbContext.Entry(item).State = EntityState.Modified;
            await BlogDbContext.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(TEntity item)
        {
            BlogDbContext.Entry(item).State = EntityState.Deleted;
            await BlogDbContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetItemsAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> convertQuery)
        {
            return await convertQuery(NotCachedQueryable).ToListAsync();
        }
    }


    public abstract class GenericRepositoryBase<TEntity, TKey> : GenericRepositoryBase<TEntity>, IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity
    {
        protected GenericRepositoryBase(BlogDbContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<TEntity> GetItemAsync(TKey itemId)
        {
            return await NotCachedQueryable.FirstOrDefaultAsync(KeyPredicate(itemId));
        }

        public virtual async Task RemoveAsync(TKey itemId)
        {
            var item = await GetItemAsync(itemId);
            await RemoveAsync(item);
            await BlogDbContext.SaveChangesAsync();
        }

        protected abstract Expression<Func<TEntity, bool>> KeyPredicate(TKey key);
    }
}