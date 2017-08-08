using System.Collections.Generic;
using Blog.Business.Infrastructure;

namespace Blog.Business.Models.QuestionaryAnswerModels
{
    /// <summary>
    /// The class representing a full questionary.
    /// It will be divided into questionary answers.
    /// </summary>
    public class QuestionaryModel
    {
        public string City { get; set; }
        public string Wishes { get; set; }
        public AgeRange AgeRange { get; set; }
        public HowLongReadBlog HowLongReadBlog { get; set; }
        public IEnumerable<InterestingTypes> Interestings { get; set; }
    }
}