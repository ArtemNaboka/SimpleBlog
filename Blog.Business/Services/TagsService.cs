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
    public class TagsService : ITagsService
    {
        private readonly ITagsRepository _tagsRepository;

        public TagsService(ITagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        public async Task CreateAsync(TagModel tag)
        {
            await _tagsRepository.AddAsync(Mapper.Map<TagModel, Tag>(tag));
        }

        public async Task<IEnumerable<ArticleModel>> GetArticlesByTag(int tagId)
        {
            var tag = await _tagsRepository.GetItemAsync(tagId);
            var articles = tag.ArticleTags.Select(at => at.Article);
            return Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleModel>>(articles);
        }

        public async Task<IEnumerable<TagModel>> GetTags()
        {
            var tags = await _tagsRepository.GetItemsAsync();
            return Mapper.Map<IEnumerable<Tag>, IEnumerable<TagModel>>(tags);
        }
    }
}