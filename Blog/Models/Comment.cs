using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }

        [ScaffoldColumn(false)]
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }
    }
}