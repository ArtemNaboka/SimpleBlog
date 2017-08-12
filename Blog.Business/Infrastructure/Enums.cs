using System.ComponentModel;

namespace Blog.Business.Infrastructure
{
    #region Enums

    public enum HowLongReadBlog
    {
        [Description("> 1 year")]
        LessThanOneYear,

        [Description("1-2 years")]
        FromOneToTwoYears,

        [Description("3+ years")]
        MoreThanThreeYears
    }

    public enum AgeRange
    {
        [Description("0-17")]
        LessThanEighteen,

        [Description("18-45")]
        BetweenEighteenAndFourtyFive,

        [Description("45-60")]
        BetweenFourtySixAndSixty,

        [Description("60+")]
        MoreThanSixty
    }

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

    public enum NetTechnologies
    {
        AspNetMvc,
        Wcf,
        Wpf,
        WebApi
    }

    #endregion
}