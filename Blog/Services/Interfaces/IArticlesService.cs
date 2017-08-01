using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Models.Entities;

namespace Blog.Services.Interfaces
{
    public interface IArticlesService
    {
        Task<IEnumerable<Article>> GetArticlesAsync();
        Task<Article> GetArticleAsync(int articleId);
        Task<IEnumerable<Article>> FindByDateAsync(DateTime date);
        Task CreateAsync(Article article);
        Task UpdateAsync(Article article);
        Task RemoveAsync(int articleId);
    }
}