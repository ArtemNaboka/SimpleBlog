using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Infrastructure;
using Blog.Models;
using Blog.Repositories.Interfaces;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class QuestionariesService : IQuestionariesService
    {
        private readonly IQuestionariesRepository _questionariesRepository;

        public QuestionariesService(IQuestionariesRepository questionariesRepository)
        {
            _questionariesRepository = questionariesRepository;
        }

        public async Task<QuestionaryResults> GetStatistics()
        {
            var qResults = new QuestionaryResults();
            var grouped = (await _questionariesRepository.GetItemsAsync()).GroupBy(q => q.QuestionType);

            qResults.CityStatistics = GetStatisticsForGroup(grouped, QuestionaryCases.QuestionaryTypes.City);
            qResults.InterestingsStatistics = GetStatisticsForGroup(grouped,
                QuestionaryCases.QuestionaryTypes.Interestings);
            qResults.AgeRangeStatistics = GetStatisticsForGroup(grouped, QuestionaryCases.QuestionaryTypes.AgeRange);
            qResults.HowLongReadBlogStatistics = GetStatisticsForGroup(grouped,
                QuestionaryCases.QuestionaryTypes.HowLongReadBlog);


            return qResults;
        }

        public async Task AddAsync(Questionary questionary)
        {
            questionary.AnsweredCount = 1;
            await _questionariesRepository.AddAsync(questionary);
        }

        public async Task AddRangeAsync(IEnumerable<Questionary> answers)
        {
            foreach (var answer in answers)
            {
                await AddAsync(answer);
            }
        }


        #region Privates

        private IEnumerable<Statistics> GetStatisticsForGroup(
            IEnumerable<IGrouping<string, Questionary>> grouped,
            QuestionaryCases.QuestionaryTypes type)
        {
            var groupedByType = grouped.Where(g => g.Key == type.ToString());
            var result = new List<Statistics>();
            foreach (var groupedItem in groupedByType)
            {
                var generalAnsweredCount = groupedItem.Sum(ageRange => ageRange.AnsweredCount);

                result.AddRange(groupedItem.Select(ageRangesAnswer => new Statistics
                {
                    Answer = ageRangesAnswer.Answer,
                    AnsweredCount = ageRangesAnswer.AnsweredCount,
                    AnsweredPercent = (int)Math.Round((double)ageRangesAnswer.AnsweredCount / generalAnsweredCount * 100)
                }));
            }
            return result;
        }

        #endregion
    }
}