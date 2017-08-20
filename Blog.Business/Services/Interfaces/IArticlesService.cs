using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Business.Models.DTO;

namespace Blog.Business.Services.Interfaces
{
    public interface IArticlesService : IService<ArticleModel>
    {
        Task<IEnumerable<ArticleModel>> GetArticlesAsync();
        Task<ArticleModel> GetArticleAsync(int articleId);
        Task<IEnumerable<ArticleModel>> FindByDateAsync(DateTime date);
        Task CreateAsync(ArticleModel article);
        Task CreateAsync(ArticleModel article, IEnumerable<int> tagsId);
        Task UpdateAsync(ArticleModel article);
        Task RemoveAsync(int articleId);
        Task<IEnumerable<TagModel>> GetArticleTags(int articleId);
        Task AddTagToArticle(int articleId, int tagId);
        Task AddTagsToArticle(int articleId, IEnumerable<int> tagsId);
    }
}