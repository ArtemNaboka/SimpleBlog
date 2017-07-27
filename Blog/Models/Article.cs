using System;

namespace Blog.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }
    }
}