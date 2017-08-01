using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Blog.Infrastructure;

namespace Blog.ViewModels
{
    public class InterestingsViewModel
    {
        [Display(Name = "What are your interesting on this blog?")]
        public IEnumerable<LabelValuePair<bool>> Checkboxes { get; set; } = QuestionaryCases.Interestings;
    }
}