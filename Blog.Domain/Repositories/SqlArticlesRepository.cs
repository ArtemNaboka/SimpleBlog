using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public override Task RemoveAsync(Article item)
        {
            var article = DbSet.Include(a => a.ArticleTags).First(a => a.Id == item.Id);
            foreach (var articleTag in article.ArticleTags.ToList())
            {
                BlogDbContext.Entry(articleTag).State = EntityState.Deleted;
            }

            return base.RemoveAsync(article);
        }

        protected override IQueryable<Article> NotCachedQueryable => DbSet.Include(a => a.ArticleTags).AsNoTracking();
        protected override Expression<Func<Article, bool>> KeyPredicate(int key) => (e => e.Id == key);
    }
}