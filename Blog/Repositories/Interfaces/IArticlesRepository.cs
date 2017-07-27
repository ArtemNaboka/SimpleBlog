using Blog.Models;

namespace Blog.Repositories.Interfaces
{
    public interface IArticlesRepository : ICrudRepository<Article, int>
    {
        
    }
}