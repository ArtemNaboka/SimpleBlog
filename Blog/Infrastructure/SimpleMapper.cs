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

            foreach (var interesting in viewModel.Interestings.Checkboxes)
            {
                if (interesting.Value)
                {
                    questionaries.Add(new Questionary { Answer = interesting.Label, QuestionType = "Interestings" });
                }
            }

            return questionaries;
        }
    }
}