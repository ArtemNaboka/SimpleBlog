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
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public async Task<IEnumerable<CommentModel>> GetCommentsAsync()
        {
            var comments = await _commentsRepository.GetItemsAsync();
            return Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public async Task<CommentModel> GetCommentAsync(int commentId)
        {
            var comment = await _commentsRepository.GetItemAsync(commentId);
            return Mapper.Map<Comment, CommentModel>(comment);
        }

        public async Task<IEnumerable<CommentModel>> FindByAuthorName(string authorName)
        {
            var comments = await _commentsRepository
                .GetItemsAsync(comms => comms.Where(c => c.AuthorName == authorName));

            return Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public async Task<IEnumerable<CommentModel>> FindByDateAsync(DateTime date)
        {
            var comments = await _commentsRepository
                .GetItemsAsync(comms => comms.Where(c => c.PublishDate == date));

            return Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentModel>>(comments);
        }

        public async Task CreateAsync(CommentModel comment)
        {
            comment.PublishDate = DateTime.UtcNow;
            await _commentsRepository.AddAsync(Mapper.Map<CommentModel, Comment>(comment));
        }

        public async Task UpdateAsync(CommentModel comment)
        {
            await _commentsRepository.UpdateAsync(Mapper.Map<CommentModel, Comment>(comment));
        }

        public async Task RemoveAsync(int commentId)
        {
            await _commentsRepository.RemoveAsync(commentId);
        }
    }
}