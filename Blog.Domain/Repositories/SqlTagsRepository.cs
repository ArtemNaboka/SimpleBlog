using System;
using System.Linq.Expressions;
using Blog.Domain.Contexts.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Repositories.Base;
using Blog.Domain.Repositories.Interfaces;

namespace Blog.Domain.Repositories
{
    public class SqlTagsRepository : GenericRepositoryBase<Tag, int>, ITagsRepository
    {
        public SqlTagsRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        protected override Expression<Func<Tag, bool>> KeyPredicate(int key) => (e => e.Id == key);
    }
}