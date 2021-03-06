﻿using System.Collections.Generic;

namespace Blog.Infrastructure
{
    public class QuestionaryCases
    {
        public enum QuestionaryTypes
        {
            City,
            Wishes,
            AgeRange,
            HowLongReadBlog,
            Interestings
        }

        public enum InterestingTypes
        {
            ExpiriencedAuthors,
            ManyCodeExamples,
            RelevantTechnologies,
            Other
        }

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

        public static readonly IEnumerable<LabelValuePair<bool>> Interestings = new[]
        {
            new LabelValuePair<bool>("Many code examples"),
            new LabelValuePair<bool>("The most relevant technologies"),
            new LabelValuePair<bool>("Very expirienced authors"),
            new LabelValuePair<bool>("Other"),
        };
    }
}