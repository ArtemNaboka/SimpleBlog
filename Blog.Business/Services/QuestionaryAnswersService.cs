using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Business.Infrastructure;
using Blog.Business.Models.DTO;
using Blog.Business.Models.QuestionaryAnswerModels;
using Blog.Business.Services.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Repositories.Interfaces;

namespace Blog.Business.Services
{
    public class QuestionaryAnswersService : IQuestionaryAnswersService
    {
        private readonly IQuestionaryAnswersRepository _questionariesRepository;

        public QuestionaryAnswersService(IQuestionaryAnswersRepository questionariesRepository)
        {
            _questionariesRepository = questionariesRepository;
        }

        public async Task CreateQuestionaryAsync(QuestionaryModel model)
        {
            var qList = new List<QuestionaryAnswerModel>
            {
                new QuestionaryAnswerModel
                {
                    Answer = model.City,
                    QuestionType = QuestionaryCasesProvider.QuestionTypesStrings[QuestionaryTypes.City]
                },
                new QuestionaryAnswerModel
                {
                    Answer = model.Wishes,
                    QuestionType = QuestionaryCasesProvider.QuestionTypesStrings[QuestionaryTypes.Wishes]
                },
                new QuestionaryAnswerModel
                {
                    Answer = QuestionaryCasesProvider.AgeRangeStringMatches[model.AgeRange],
                    QuestionType = QuestionaryCasesProvider.QuestionTypesStrings[QuestionaryTypes.AgeRange]
                },
                new QuestionaryAnswerModel
                {
                    Answer = QuestionaryCasesProvider.HowLongReadBlogStringMatches[model.HowLongReadBlog],
                    QuestionType = QuestionaryCasesProvider.QuestionTypesStrings[QuestionaryTypes.HowLongReadBlog]
                }
            };

            qList.AddRange(model.Interestings.Select(interesting => new QuestionaryAnswerModel
            {
                Answer = QuestionaryCasesProvider.InterestingsStringMatchces[interesting],
                QuestionType = QuestionaryCasesProvider.QuestionTypesStrings[QuestionaryTypes.Interestings]
            }));

            await AddRangeAsync(qList);
        }

        public async Task<QuestionaryResults> GetStatistics()
        {
            var qResults = new QuestionaryResults();
            var grouped = (await _questionariesRepository.GetItemsAsync()).GroupBy(q => q.QuestionType).ToList();

            qResults.CityStatistics = GetStatisticsForGroup(grouped, QuestionaryTypes.City);
            qResults.InterestingsStatistics = GetStatisticsForGroup(grouped,
                QuestionaryTypes.Interestings);
            qResults.AgeRangeStatistics = GetStatisticsForGroup(grouped, QuestionaryTypes.AgeRange);
            qResults.HowLongReadBlogStatistics = GetStatisticsForGroup(grouped,
                QuestionaryTypes.HowLongReadBlog);


            return qResults;
        }

        public async Task AddAsync(QuestionaryAnswerModel questionary)
        {
            questionary.AnsweredCount = 1;
            await _questionariesRepository.AddAsync(Mapper.Map<QuestionaryAnswerModel, QuestionaryAnswer>(questionary));
        }

        public async Task AddRangeAsync(IEnumerable<QuestionaryAnswerModel> answers)
        {
            foreach (var answer in answers)
            {
                await AddAsync(answer);
            }
        }


        #region Privates

        private IEnumerable<Statistics> GetStatisticsForGroup(
            IEnumerable<IGrouping<string, QuestionaryAnswer>> grouped,
            QuestionaryTypes type)
        {
            var groupedByType = grouped.Where(g => g.Key == QuestionaryCasesProvider.QuestionTypesStrings[type]);
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

        private QuestionaryAnswerModel GetQuestionaryAnswerModel(string answer, string questionType)
        {
            return new QuestionaryAnswerModel
            {
                Answer = answer,
                QuestionType = questionType
            };
        }

        #endregion
    }
}