using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.Entities.Base;

namespace Blog.Domain.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity: BaseEntity
    {
        Task<IEnumerable<TEntity>> GetItemsAsync();
        Task<IEnumerable<TEntity>> GetItemsAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> convertQuery);
        Task AddAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task RemoveAsync(TEntity item);
    }


    public interface IGenericRepository<TEntity, in TKey> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> GetItemAsync(TKey itemId);
        Task RemoveAsync(TKey itemId);
    }
}