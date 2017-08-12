using System.Collections.Generic;
using Blog.WebUI.ViewModels.VoteViewModels;

namespace Blog.WebUI.ViewModels.ArticleViewModels
{
    public class ArticlesListViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }
        public CreateVoiceViewModel Voice { get; set; }
        public VoteResultsViewModel VoteResults { get; set; }
        public bool UserHasVoted { get; set; }
    }
}