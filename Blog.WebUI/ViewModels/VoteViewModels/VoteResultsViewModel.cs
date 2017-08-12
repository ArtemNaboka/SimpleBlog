using System.Collections.Generic;
using Blog.Business.Models.QuestionaryAnswerModels;

namespace Blog.WebUI.ViewModels.VoteViewModels
{
    public class VoteResultsViewModel
    {
        public IEnumerable<Statistics> Results { get; set; }
    }
}