using System.Collections.Generic;

namespace Blog.Infrastructure
{
    public class QuestionaryCases
    {
        public static readonly IEnumerable<KeyValuePair<string, string>> AgeRangeValuesAndLabels = new[]
        {
            new KeyValuePair<string, string>("< 18", "> 18"),
            new KeyValuePair<string, string>("19-45", "19-45"),
            new KeyValuePair<string, string>("46-60", "46-60"),
            new KeyValuePair<string, string>("60 <", "60 <")
        };

        public static readonly IEnumerable<KeyValuePair<string, string>> HowLongReadBlogValuesAndLabels = new[]
        {
            new KeyValuePair<string, string>("< 1 year", "< 1 year"),
            new KeyValuePair<string, string>("1-2 years", "1-2 years"),
            new KeyValuePair<string, string>("3 years <", "3 years <")
        };
    }
}