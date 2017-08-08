using System;
using System.Linq.Expressions;
using Blog.Domain.Contexts.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Repositories.Base;
using Blog.Domain.Repositories.Interfaces;

namespace Blog.Domain.Repositories
{
    public class SqlArticlesRepository : GenericRepositoryBase<Article, int>, IArticlesRepository
    {
        public SqlArticlesRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        protected override Expression<Func<Article, bool>> KeyPredicate(int key) => (e => e.Id == key);
    }
}