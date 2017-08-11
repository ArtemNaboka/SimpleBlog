using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.ViewModels.ArticleViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public DateTime PublishDate { get; set; }

        [Required]
        public string Text { get; set; }

        [DataType(DataType.MultilineText)]
        public string Tags { get; set; }
    }
}