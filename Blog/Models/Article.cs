using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Article Name")]
        public string Name { get; set; }

        [Display(Name = "Date of Publish")]
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime PublishDate { get; set; }

        [Required]
        [Display(Name = "Text")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}