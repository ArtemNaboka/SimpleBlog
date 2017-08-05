using System.Collections.Generic;

namespace Blog.WebUI.ViewModels.CommentViewModels
{
    public class CommentsListViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public int CommentsCount { get; set; }
        public CommentViewModel CommentToAdd { get; set; }
    }
}