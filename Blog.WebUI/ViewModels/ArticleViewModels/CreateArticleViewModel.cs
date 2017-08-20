using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Blog.Business.Models.DTO;

namespace Blog.WebUI.ViewModels.ArticleViewModels
{
    public class CreateArticleViewModel
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

        [Display(Name = "Tags")]
        public IEnumerable<int> ChoosenTagsId { get; set; }

        public IEnumerable<SelectListItem> Tags { get; set; }
    }
}