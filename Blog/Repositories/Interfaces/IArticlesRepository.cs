using Blog.Models;
using Blog.Models.Entities;

namespace Blog.Repositories.Interfaces
{
    public interface IArticlesRepository : ICrudRepository<Article, int>
    {
        
    }
}