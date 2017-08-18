using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Domain.Contexts.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Repositories.Base;
using Microsoft.AspNet.Identity;

namespace Blog.Domain.Repositories
{
    public class SqlUserStore : GenericRepositoryBase<User, int>, IUserStore<User, int>
    {
        public SqlUserStore(IDbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateAsync(User user)
        {
            await AddAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            await RemoveAsync(user);
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            return await GetItemAsync(userId);
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            var user = (await GetItemsAsync(e => e.Where(u => u.UserName == userName))).FirstOrDefault();
            return user;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            
        }

        protected override Expression<Func<User, bool>> KeyPredicate(int key) => (e => e.Id == key);
    }
}