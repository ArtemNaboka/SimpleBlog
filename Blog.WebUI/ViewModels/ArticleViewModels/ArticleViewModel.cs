using System;
using System.Collections.Generic;
using Blog.Business.Models.DTO;

namespace Blog.WebUI.ViewModels.ArticleViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime PublishDate { get; set; }

        public string Text { get; set; }

        public ICollection<TagModel> Tags { get; set; }
    }
}