using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Business.Models.DTO;
using Blog.Domain.Entities;

namespace Blog.Business.Services.Interfaces
{
    public interface ICommentsService : IService<CommentModel>
    {
        Task<IEnumerable<CommentModel>> GetCommentsAsync();
        Task<CommentModel> GetCommentAsync(int commentId);
        Task<IEnumerable<CommentModel>> FindByAuthorName(string authorName);
        Task<IEnumerable<CommentModel>> FindByDateAsync(DateTime date);
        Task CreateAsync(CommentModel comment);
        Task UpdateAsync(CommentModel comment);
        Task RemoveAsync(int commentId);
    }
}