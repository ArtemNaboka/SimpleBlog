using System;
using System.ComponentModel.DataAnnotations;
using Blog.Models.Entities.Base;

namespace Blog.Models.Entities
{
    public class Article : BaseEntity
    {
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