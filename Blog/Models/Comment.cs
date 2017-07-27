using System;

namespace Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }
    }
}