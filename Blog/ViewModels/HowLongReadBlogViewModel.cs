using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Blog.Infrastructure;

namespace Blog.ViewModels
{
    public class HowLongReadBlogViewModel
    {
        [Required]
        [Display(Name = "How long have you been reading a blog")]
        public string Value { get; set; }

        public Dictionary<string, string> ValuesAndLabels { get; set; } =
            QuestionaryCases.HowLongReadBlogValuesAndLabels;
    }
}