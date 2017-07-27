using Blog.Models;

namespace Blog.Repositories.Interfaces
{
    public interface ICommentsRepository : ICrudRepository<Comment, int>
    {
        
    }
}