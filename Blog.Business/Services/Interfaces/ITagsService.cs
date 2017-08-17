using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Business.Models.DTO;

namespace Blog.Business.Services.Interfaces
{
    public interface ITagsService
    {
        Task CreateAsync(TagModel tag);
        Task<IEnumerable<ArticleModel>> GetArticlesByTag(int tagId);
    }
}