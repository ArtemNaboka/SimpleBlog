using Blog.Models;
using Blog.Models.Entities;

namespace Blog.Repositories.Interfaces
{
    public interface ICommentsRepository : ICrudRepository<Comment, int>
    {
        
    }
}