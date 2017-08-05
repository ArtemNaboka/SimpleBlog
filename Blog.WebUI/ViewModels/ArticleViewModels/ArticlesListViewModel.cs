using System.Collections.Generic;

namespace Blog.WebUI.ViewModels.ArticleViewModels
{
    public class ArticlesListViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}