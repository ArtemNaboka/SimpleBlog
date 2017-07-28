using System.Collections.Generic;
using Blog.Models;

namespace Blog.ViewModels
{
    public class CommentsListViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
        public int CommentsCount { get; set; }
    }
}