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
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            var comments = await _commentsRepository.GetItemsAsync();
            return comments;
        }

        public async Task<Comment> GetCommentAsync(int commentId)
        {
            var comment = await _commentsRepository.GetItemAsync(commentId);
            return comment;
        }

        public async Task<IEnumerable<Comment>> FindByAuthorName(string authorName)
        {
            var comments = await _commentsRepository
                .GetItemsAsync(comms => comms.Where(c => c.AuthorName == authorName));

            return comments;
        }

        public async Task<IEnumerable<Comment>> FindByDateAsync(DateTime date)
        {
            var comments = await _commentsRepository
                .GetItemsAsync(comms => comms.Where(c => c.PublishDate == date));

            return comments;
        }

        public async Task CreateAsync(Comment comment)
        {
            comment.PublishDate = DateTime.UtcNow;
            await _commentsRepository.AddAsync(comment);
        }

        public async Task UpdateAsync(Comment comment)
        {
            await _commentsRepository.UpdateAsync(comment);
        }

        public async Task RemoveAsync(int commentId)
        {
            await _commentsRepository.RemoveAsync(commentId);
        }
    }
}