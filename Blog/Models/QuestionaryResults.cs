using System.Collections.Generic;

namespace Blog.Models
{
    public class QuestionaryResults
    {
        public IEnumerable<Statistics> CityStatistics { get; set; }
        public IEnumerable<Statistics> InterestingsStatistics { get; set; }
        public IEnumerable<Statistics> AgeRangeStatistics { get; set; }
        public IEnumerable<Statistics> HowLongReadBlogStatistics { get; set; }
    }
}