using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Contexts;
using Blog.Repositories.Interfaces;

namespace Blog.Repositories.Base
{
    public abstract class CrudRepositoryBase<TEntity> : ICrudRepository<TEntity> 
        where TEntity: class
    {
        protected CrudRepositoryBase(BlogDbContext dbContext)
        {
            BlogDbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public DbSet<TEntity> DbSet { get; }
        public BlogDbContext BlogDbContext { get; }
        public virtual IQueryable<TEntity> NotCachedQueryable => DbSet.AsNoTracking();

        public async Task<IEnumerable<TEntity>> GetItemsAsync()
        {
            return await NotCachedQueryable.ToListAsync();
        }

        public async Task AddAsync(TEntity item)
        {
            DbSet.Add(item);
            await BlogDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity item)
        {
            BlogDbContext.Entry(item).State = EntityState.Modified;
            await BlogDbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity item)
        {
            DbSet.Remove(item);
            await BlogDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetItemsAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> convertQuery)
        {
            return await convertQuery(NotCachedQueryable).ToListAsync();
        }
    }


    public abstract class CrudRepositoryBase<TEntity, TKey> : CrudRepositoryBase<TEntity>,
        ICrudRepository<TEntity, TKey>
        where TEntity : class
    {
        protected CrudRepositoryBase(BlogDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TEntity> GetItemAsync(TKey itemId)
        {
            return await NotCachedQueryable.FirstOrDefaultAsync(KeyPredicate(itemId));
        }

        public async Task RemoveAsync(TKey itemId)
        {
            var item = await GetItemAsync(itemId);
            DbSet.Remove(item);
            await BlogDbContext.SaveChangesAsync();
        }

        protected abstract Expression<Func<TEntity, bool>> KeyPredicate(TKey key);
    }
}