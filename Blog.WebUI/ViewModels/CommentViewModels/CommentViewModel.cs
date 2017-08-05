using System;

namespace Blog.WebUI.ViewModels.CommentViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }
    }
}