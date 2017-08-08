using System.Collections.Generic;
using Blog.Business.Models.QuestionaryAnswerModels;

namespace Blog.WebUI.ViewModels.QuestionariesViewModels
{
    public class QuestionaryResultsViewModel
    {
        public IEnumerable<Statistics> CityStatistics { get; set; }
        public IEnumerable<Statistics> InterestingsStatistics { get; set; }
        public IEnumerable<Statistics> AgeRangeStatistics { get; set; }
        public IEnumerable<Statistics> HowLongReadBlogStatistics { get; set; }
    }
}