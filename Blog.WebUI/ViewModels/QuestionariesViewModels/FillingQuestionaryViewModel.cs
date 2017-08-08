using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Blog.Business.Infrastructure;

namespace Blog.WebUI.ViewModels.QuestionariesViewModels
{
    public class FillingQuestionaryViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Your city")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Wishes for the blog")]
        public string Wishes { get; set; }

        [Display(Name = "Your age")]
        public AgeRangeViewModel AgeRange { get; set; } = new AgeRangeViewModel();

        [Display(Name = "How long do you read our blog?")]
        public HowLongReadBlogViewModel HowLongReadBlog { get; set; } = new HowLongReadBlogViewModel();

        [Display(Name = "Your interestings")]
        public InterestingsViewModel Interestings { get; set; } = new InterestingsViewModel();
        public IEnumerable<InterestingTypes> InterestingsValues { get; set; }
    }
}