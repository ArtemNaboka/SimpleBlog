using System.Collections.Generic;
using Blog.Models;
using Blog.Models.Entities;

namespace Blog.ViewModels
{
    public class ArticlesListViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}