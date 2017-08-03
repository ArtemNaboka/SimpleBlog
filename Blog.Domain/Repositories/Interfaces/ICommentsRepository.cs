using Blog.Domain.Entities;

namespace Blog.Domain.Repositories.Interfaces
{
    public interface ICommentsRepository : IGenericRepository<Comment, int>
    {
        
    }
}