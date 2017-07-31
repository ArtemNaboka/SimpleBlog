using System.Collections.Generic;

namespace Blog.Infrastructure
{
    public class QuestionaryCases
    {
        public static readonly Dictionary<string, string> AgeRangeValuesAndLabels = new Dictionary<string, string>
        {
            ["< 18"] = "> 18",
            ["19-45"] = "19-45",
            ["46-60"] = "46-60",
            ["60 <"] = "60 <"
        };

        public static readonly Dictionary<string, string> HowLongReadBlogValuesAndLabels = new Dictionary<string, string>
        {
            ["< 1 year"] = "< 1 year",
            ["1-2 years"] = "1-2 years",
            ["3 years <"] = "3 years <"
        };
    }
}