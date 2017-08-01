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
                new Questionary {Answer = viewModel.City, QuestionType = nameof(viewModel.City)},
                new Questionary {Answer = viewModel.Wishes, QuestionType = nameof(viewModel.Wishes)},
                new Questionary {Answer = viewModel.AgeRange.Value, QuestionType = nameof(viewModel.AgeRange)},
                new Questionary {Answer = viewModel.HowLongReadBlog.Value, QuestionType = nameof(viewModel.HowLongReadBlog)}
            };

            if (viewModel.Interestings.ExpiriencedAuthors)
            {
                questionaries.Add(new Questionary
                {
                    Answer = nameof(viewModel.Interestings.ExpiriencedAuthors),
                    QuestionType = nameof(viewModel.Interestings)
                });
            }

            if (viewModel.Interestings.ManyCodeExamples)
            {
                questionaries.Add(new Questionary
                {
                    Answer = nameof(viewModel.Interestings.ManyCodeExamples),
                    QuestionType = nameof(viewModel.Interestings)
                });
            }

            if (viewModel.Interestings.RelevantTechnologies)
            {
                questionaries.Add(new Questionary
                {
                    Answer = nameof(viewModel.Interestings.RelevantTechnologies),
                    QuestionType = nameof(viewModel.Interestings)
                });
            }

            if (viewModel.Interestings.Other)
            {
                questionaries.Add(new Questionary
                {
                    Answer = nameof(viewModel.Interestings.Other),
                    QuestionType = nameof(viewModel.Interestings)
                });
            }

            return questionaries;
        }
    }
}