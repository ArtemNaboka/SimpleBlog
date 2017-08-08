using System.Collections.Generic;

namespace Blog.Business.Infrastructure
{
    public static class QuestionaryCasesProvider
    {
        public static Dictionary<QuestionaryTypes, string> QuestionTypesStrings => new Dictionary<QuestionaryTypes, string>
        {
            [QuestionaryTypes.AgeRange] = "Age range",
            [QuestionaryTypes.City] = "City",
            [QuestionaryTypes.HowLongReadBlog] = "How long user reads blog",
            [QuestionaryTypes.Interestings] = "Interestings in blog",
            [QuestionaryTypes.Wishes] = "Wishes"
        };

        public static Dictionary<AgeRange, string> AgeRangeValuesAndLabels => new Dictionary<AgeRange, string>
        {
            [AgeRange.LessThanEighteen] = "> 18",
            [AgeRange.BetweenEighteenAndFourtyFive] = "18-45",
            [AgeRange.BetweenFourtySixAndSixty] = "46-60",
            [AgeRange.MoreThanSixty] = "60 <"
        };

        public static Dictionary<HowLongReadBlog, string> HowLongReadBlogValues => new Dictionary<HowLongReadBlog, string>
        {
            [HowLongReadBlog.LessThanOneYear] = "> 1",
            [HowLongReadBlog.FromOneToTwoYears] = "1-2",
            [HowLongReadBlog.MoreThanThreeYears] = "3 <"
        };

        public static Dictionary<InterestingTypes, string> InterestingsValues => new Dictionary<InterestingTypes, string>
        {
            [InterestingTypes.ExpiriencedAuthors] = "Very expirienced authors",
            [InterestingTypes.ManyCodeExamples] = "Many code examples",
            [InterestingTypes.RelevantTechnologies] = "Relevant technologies",
            [InterestingTypes.Other] = "Other"
        };

    }
}