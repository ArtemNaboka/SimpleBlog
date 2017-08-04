using Blog.Domain.Entities;

namespace Blog.Domain.Repositories.Interfaces
{
    public interface IArticlesRepository : IGenericRepository<Article, int>
    {
        
    }
}