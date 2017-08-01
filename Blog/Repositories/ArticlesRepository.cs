using System;
using System.Linq.Expressions;
using Blog.Contexts;
using Blog.Models;
using Blog.Models.Entities;
using Blog.Repositories.Base;
using Blog.Repositories.Interfaces;

namespace Blog.Repositories
{
    public class ArticlesRepository : CrudRepositoryBase<Article, int>, IArticlesRepository
    {
        public ArticlesRepository(BlogDbContext dbContext) : base(dbContext)
        {

        }

        protected override Expression<Func<Article, bool>> KeyPredicate(int key) => (e => e.Id == key);
    }
}