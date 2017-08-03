using System;
using Blog.Domain.Entities.Base;

namespace Blog.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string AuthorName { get; set; }
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }
    }
}