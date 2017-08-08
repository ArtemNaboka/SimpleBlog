using System.Collections.Generic;
using Blog.Business.Infrastructure;

namespace Blog.WebUI.ViewModels.QuestionariesViewModels
{
    public class AgeRangeViewModel
    {
        public AgeRange Value { get; set; }
        public Dictionary<AgeRange, string> ValuesAndLabels { get; set; } = QuestionaryCasesProvider.AgeRangeStringMatches;
    }
}