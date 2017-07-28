using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Your name")]
        public string AuthorName { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Date of publishing")]
        public DateTime PublishDate { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comment")]
        public string Text { get; set; }
    }
}