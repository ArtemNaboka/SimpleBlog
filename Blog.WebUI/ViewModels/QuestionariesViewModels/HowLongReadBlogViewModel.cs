using System.Collections.Generic;
using Blog.Business.Infrastructure;

namespace Blog.WebUI.ViewModels.QuestionariesViewModels
{
    public class HowLongReadBlogViewModel
    {
        public HowLongReadBlog Value { get; set; }
        public Dictionary<HowLongReadBlog, string> ValuesAndLabels { get; set; } = 
            QuestionaryCasesProvider.HowLongReadBlogValues;
    }
}