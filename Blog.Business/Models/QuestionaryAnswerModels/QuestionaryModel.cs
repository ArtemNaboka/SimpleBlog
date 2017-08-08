using System.Collections.Generic;
using Blog.Business.Infrastructure;

namespace Blog.Business.Models.QuestionaryAnswerModels
{
    public class QuestionaryModel
    {
        public string City { get; set; }
        public string Wishes { get; set; }
        public AgeRange AgeRange { get; set; }
        public HowLongReadBlog HowLongReadBlog { get; set; }
        public IEnumerable<InterestingTypes> Interestings { get; set; }
    }
}