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
    public class SqlRoleStore : GenericRepositoryBase<Role, int>, IRoleStore<Role, int>
    {
        public SqlRoleStore(IDbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateAsync(Role role)
        {
            await AddAsync(role);
        }

        public async Task DeleteAsync(Role role)
        {
            await RemoveAsync(role);
        }

        public async Task<Role> FindByIdAsync(int roleId)
        {
            return await GetItemAsync(roleId);
        }

        public async Task<Role> FindByNameAsync(string roleName)
        {
            var roles = await GetItemsAsync(x => x.Where(r => r.Name == roleName));
            return roles.FirstOrDefault();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            
        }

        protected override Expression<Func<Role, bool>> KeyPredicate(int key) => (e => e.Id == key);
    }
}