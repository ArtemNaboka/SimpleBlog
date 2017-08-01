using System.Collections.Generic;
using Blog.Models;
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
                    Answer = nameof(viewModel.Interestings.ExpiriencedAuthors),
                    QuestionType = QuestionaryCases.QuestionaryTypes.Interestings.ToString()
                });
            }

            if (viewModel.Interestings.ManyCodeExamples)
            {
                questionaries.Add(new Questionary
                {
                    Answer = nameof(viewModel.Interestings.ManyCodeExamples),
                    QuestionType = QuestionaryCases.QuestionaryTypes.Interestings.ToString()
                });
            }

            if (viewModel.Interestings.RelevantTechnologies)
            {
                questionaries.Add(new Questionary
                {
                    Answer = nameof(viewModel.Interestings.RelevantTechnologies),
                    QuestionType = QuestionaryCases.QuestionaryTypes.Interestings.ToString()
                });
            }

            if (viewModel.Interestings.Other)
            {
                questionaries.Add(new Questionary
                {
                    Answer = nameof(viewModel.Interestings.Other),
                    QuestionType = QuestionaryCases.QuestionaryTypes.Interestings.ToString()
                });
            }

            return questionaries;
        }
    }
}