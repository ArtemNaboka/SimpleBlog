using System;
using Blog.Domain.Entities.Base;

namespace Blog.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }
        public string Tags { get; set; }
    }
}
