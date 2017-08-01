using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Models.Entities;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly IArticlesRepository _articlesRepository;

        public ArticlesService(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public async Task<IEnumerable<Article>> GetArticlesAsync()
        {
            var articles = await _articlesRepository.GetItemsAsync();
            return articles;
        }

        public async Task<Article> GetArticleAsync(int articleId)
        {
            var article = await _articlesRepository.GetItemAsync(articleId);
            return article;
        }

        public async Task<IEnumerable<Article>> FindByDateAsync(DateTime date)
        {
            var articles = await _articlesRepository.GetItemsAsync(arts => arts.Where(a => a.PublishDate == date));
            return articles;
        }

        public async Task CreateAsync(Article article)
        {
            article.PublishDate = DateTime.UtcNow;
            await _articlesRepository.AddAsync(article);
        }

        public async Task UpdateAsync(Article article)
        {
            await _articlesRepository.UpdateAsync(article);
        }

        public async Task RemoveAsync(int articleId)
        {
            await _articlesRepository.RemoveAsync(articleId);
        }
    }
}