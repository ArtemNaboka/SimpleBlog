using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.ViewModels.ArticleViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }
    }
}