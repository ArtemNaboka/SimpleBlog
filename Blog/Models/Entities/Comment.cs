using System;
using System.ComponentModel.DataAnnotations;
using Blog.Models.Entities.Base;

namespace Blog.Models.Entities
{
    public class Comment : BaseEntity
    {
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