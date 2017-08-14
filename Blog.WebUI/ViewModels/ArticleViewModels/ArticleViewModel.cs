using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.ViewModels.ArticleViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Article name")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Date of publish")]
        public DateTime PublishDate { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [DataType(DataType.MultilineText)]
        public string Tags { get; set; }
    }
}