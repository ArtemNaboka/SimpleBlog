using System;
using System.Linq.Expressions;
using Blog.Contexts;
using Blog.Models;
using Blog.Repositories.Base;
using Blog.Repositories.Interfaces;

namespace Blog.Repositories
{
    public class CommentsRepository : CrudRepositoryBase<Comment, int>, ICommentsRepository
    {
        public CommentsRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }

        protected override Expression<Func<Comment, bool>> KeyPredicate(int key) => (e => e.Id == key);
    }
}