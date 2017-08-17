using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Blog.Domain.Contexts.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Repositories.Base;
using Blog.Domain.Repositories.Interfaces;

namespace Blog.Domain.Repositories
{
    public class SqlArticleTagsRepository : GenericRepositoryBase<ArticleTag, int>, IArticleTagsRepository
    {
        public SqlArticleTagsRepository(IDbContext dbContext) : base(dbContext)
        {
        }


        protected override IQueryable<ArticleTag> NotCachedQueryable => DbSet
                                                                    .Include(at => at.Article)
                                                                    .Include(at => at.Tag)
                                                                    .AsNoTracking();

        protected override Expression<Func<ArticleTag, bool>> KeyPredicate(int key) => (e => e.Id == key);
    }
}