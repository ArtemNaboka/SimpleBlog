using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Blog.Infrastructure;

namespace Blog.ViewModels
{
    public class AgeRangeViewModel
    {
        [Required]
        [Display(Name = "Your age")]
        public string Value { get; set; }

        public Dictionary<string, string> ValuesAndLabels { get; set; } = QuestionaryCases.AgeRangeValuesAndLabels;
    }
}