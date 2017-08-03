using System;
using System.Linq.Expressions;
using Blog.Domain.Contexts;
using Blog.Domain.Entities;
using Blog.Domain.Repositories.Base;
using Blog.Domain.Repositories.Interfaces;

namespace Blog.Domain.Repositories
{
    public class SqlCommentsRepository : GenericRepositoryBase<Comment, int>, ICommentsRepository
    {
        public SqlCommentsRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }

        protected override Expression<Func<Comment, bool>> KeyPredicate(int key) => (e => e.Id == key);
    }
}