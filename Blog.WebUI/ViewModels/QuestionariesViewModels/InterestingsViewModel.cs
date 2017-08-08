using System.Collections.Generic;
using Blog.Business.Infrastructure;

namespace Blog.WebUI.ViewModels.QuestionariesViewModels
{
    public class InterestingsViewModel
    {
        public IEnumerable<InterestingTypes> InterestingsValues { get; set; }

        public Dictionary<InterestingTypes, string> ValuesAndLabels { get; set; } =
            QuestionaryCasesProvider.InterestingsStringMatchces;
    }
}