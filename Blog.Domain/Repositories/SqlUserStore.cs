using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Domain.Contexts.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Repositories.Base;
using Microsoft.AspNet.Identity;

namespace Blog.Domain.Repositories
{
    public class SqlUserStore : GenericRepositoryBase<User, int>,
        IUserStore<User, int>, IRoleStore<Role, int>,
        IUserRoleStore<User, int>, IUserPasswordStore<User, int>,
        IUserLockoutStore<User, int>, IUserTwoFactorStore<User, int>
    {
        protected IDbSet<Role> Roles { get; set; }
        protected IDbSet<UserRole> UserRoles { get; set; }


        public SqlUserStore(IDbContext dbContext) : base(dbContext)
        {
            Roles = dbContext.Set<Role>();
            UserRoles = dbContext.Set<UserRole>();
        }

        #region IUserStore

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

        #endregion


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            
        }

        protected override Expression<Func<User, bool>> KeyPredicate(int key) => (e => e.Id == key);

        #region IRoleStore

        public async Task CreateAsync(Role role)
        {
            Roles.Add(role);
            await BlogDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            BlogDbContext.Entry(role).State = EntityState.Modified;
            await BlogDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Role role)
        {
            BlogDbContext.Entry(role).State = EntityState.Deleted;
            await BlogDbContext.SaveChangesAsync();
        }

        async Task<Role> IRoleStore<Role, int>.FindByIdAsync(int roleId)
        {
            return await Roles.FirstOrDefaultAsync(r => r.Id == roleId);
        }

        async Task<Role> IRoleStore<Role, int>.FindByNameAsync(string roleName)
        {
            return await Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        }

        #endregion

        #region IUserRoleStore

        public async Task AddToRoleAsync(User user, string roleName)
        {
            var role = await ((IRoleStore<Role, int>)this).FindByNameAsync(roleName);
            UserRoles.Add(new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id
            });

            await BlogDbContext.SaveChangesAsync();
        }

        public async Task RemoveFromRoleAsync(User user, string roleName)
        {
            var role = await ((IRoleStore<Role, int>)this).FindByNameAsync(roleName);
            var userRole = await UserRoles.FirstOrDefaultAsync(ur => ur.UserId == user.Id && ur.RoleId == role.Id);
            BlogDbContext.Entry(userRole).State = EntityState.Deleted;
            await BlogDbContext.SaveChangesAsync();
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            var roles = await UserRoles
                .Include(ur => ur.Role)
                .AsNoTracking()
                .Where(ur => ur.UserId == user.Id)
                .Select(ur => ur.Role.Name)
                .ToListAsync();

            return roles;
        }

        public async Task<bool> IsInRoleAsync(User user, string roleName)
        {
            var role = await ((IRoleStore<Role, int>)this).FindByNameAsync(roleName);
            var userRole = await UserRoles.FirstOrDefaultAsync(ur => ur.UserId == user.Id && ur.RoleId == role.Id);

            return userRole != null;
        }

        #endregion

        #region IUserPasswordStore

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        #endregion

        #region ILockoutStore

        public async Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public async Task<int> IncrementAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task ResetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }

        public async Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserTwoFactored

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }

        #endregion
    }
}