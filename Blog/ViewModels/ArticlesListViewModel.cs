using System.Collections.Generic;
using Blog.Models;

namespace Blog.ViewModels
{
    public class ArticlesListViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}