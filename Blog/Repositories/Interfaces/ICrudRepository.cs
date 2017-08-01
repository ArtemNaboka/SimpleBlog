using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.Entities.Base;

namespace Blog.Repositories.Interfaces
{
    public interface ICrudRepository<TEntity> where TEntity: BaseEntity
    {
        Task<IEnumerable<TEntity>> GetItemsAsync();
        Task<IEnumerable<TEntity>> GetItemsAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> convertQuery);
        Task AddAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task RemoveAsync(TEntity item);
    }


    public interface ICrudRepository<TEntity, in TKey> : ICrudRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> GetItemAsync(TKey itemId);
        Task RemoveAsync(TKey itemId);
    }
}