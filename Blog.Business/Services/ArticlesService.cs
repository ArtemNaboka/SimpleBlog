using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Business.Models.DTO;
using Blog.Business.Services.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Repositories.Interfaces;

namespace Blog.Business.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly IArticlesRepository _articlesRepository;

        public ArticlesService(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public async Task<IEnumerable<ArticleModel>> GetArticlesAsync()
        {
            var articles = await _articlesRepository.GetItemsAsync();
            return Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleModel>>(articles);
        }

        public async Task<ArticleModel> GetArticleAsync(int articleId)
        {
            var article = await _articlesRepository.GetItemAsync(articleId);
            return Mapper.Map<Article, ArticleModel>(article);
        }

        public async Task<IEnumerable<ArticleModel>> FindByDateAsync(DateTime date)
        {
            var articles = await _articlesRepository.GetItemsAsync(arts => arts.Where(a => a.PublishDate == date));
            return Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleModel>>(articles);
        }

        public async Task CreateAsync(ArticleModel article)
        {
            article.PublishDate = DateTime.UtcNow;
            await _articlesRepository.AddAsync(Mapper.Map<ArticleModel, Article>(article));
        }

        public async Task UpdateAsync(ArticleModel article)
        {
            await _articlesRepository.UpdateAsync(Mapper.Map<ArticleModel, Article>(article));
        }

        public async Task RemoveAsync(int articleId)
        {
            await _articlesRepository.RemoveAsync(articleId);
        }
    }
}