using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.Services.Interfaces
{
    public interface ICommentsService
    {
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task<Comment> GetCommentAsync(int commentId);
        Task<IEnumerable<Comment>> FindByAuthorName(string authorName);
        Task<IEnumerable<Comment>> FindByDateAsync(DateTime date);
        Task CreateAsync(Comment comment);
        Task UpdateAsync(Comment comment);
        Task RemoveAsync(int commentId);
    }
}