using System.Collections.Generic;
using Blog.Models;
using Blog.Models.Entities;
using Blog.ViewModels;

namespace Blog.Infrastructure
{
    public static class SimpleMapper
    {
        public static IEnumerable<Questionary> ViewModelToQuestionary(FillingQuestionaryViewModel viewModel)
        {
            var questionaries = new List<Questionary>
            {
                new Questionary {Answer = viewModel.City, QuestionType = QuestionaryCases.QuestionaryTypes.City.ToString()},
                new Questionary {Answer = viewModel.Wishes, QuestionType = QuestionaryCases.QuestionaryTypes.Wishes.ToString()},
                new Questionary {Answer = viewModel.AgeRange.Value, QuestionType = QuestionaryCases.QuestionaryTypes.AgeRange.ToString()},
                new Questionary {Answer = viewModel.HowLongReadBlog.Value, QuestionType = QuestionaryCases.QuestionaryTypes.HowLongReadBlog.ToString()}
            };

            if (viewModel.Interestings.ExpiriencedAuthors)
            {
                questionaries.Add(new Questionary
                {
                    Answer = QuestionaryCases.InterestingTypes.ExpiriencedAuthors.ToString(),
                    QuestionType = QuestionaryCases.QuestionaryTypes.Interestings.ToString()
                });
            }

            if (viewModel.Interestings.ManyCodeExamples)
            {
                questionaries.Add(new Questionary
                {
                    Answer = QuestionaryCases.InterestingTypes.ManyCodeExamples.ToString(),
                    QuestionType = QuestionaryCases.QuestionaryTypes.Interestings.ToString()
                });
            }

            if (viewModel.Interestings.RelevantTechnologies)
            {
                questionaries.Add(new Questionary
                {
                    Answer = QuestionaryCases.InterestingTypes.RelevantTechnologies.ToString(),
                    QuestionType = QuestionaryCases.QuestionaryTypes.Interestings.ToString()
                });
            }

            if (viewModel.Interestings.Other)
            {
                questionaries.Add(new Questionary
                {
                    Answer = QuestionaryCases.InterestingTypes.Other.ToString(),
                    QuestionType = QuestionaryCases.QuestionaryTypes.Interestings.ToString()
                });
            }

            return questionaries;
        }
    }
}