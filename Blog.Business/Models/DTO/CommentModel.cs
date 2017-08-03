using System;

namespace Blog.Business.Models.DTO
{
    public class CommentModel
    {
        public string AuthorName { get; set; }
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }
    }
}