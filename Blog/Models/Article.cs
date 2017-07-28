using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Display(Name = "Article Name")]
        public string Name { get; set; }

        [Display(Name = "Date of Publish")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }
    }
}