using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Business.Infrastructure;
using Blog.Business.Models.DTO;
using Blog.Business.Models.VoteModels;
using Blog.Business.Services.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Repositories.Interfaces;

namespace Blog.Business.Services
{
    public class VoteService : IVoteService
    {
        private const string VoteTypeStringValue = "Technology for articles";
        private static Dictionary<NetTechnologies, string> StringTechnologiesMathces => new Dictionary<NetTechnologies, string>
        {
            [NetTechnologies.AspNetMvc] = "ASP.NET MVC",
            [NetTechnologies.Wcf] = "WCF",
            [NetTechnologies.Wpf] = "WPF",
            [NetTechnologies.WebApi] = "Web Api"
        };

        private readonly IQuestionaryAnswersRepository _questionaryAnswersRepository;

        public VoteService(IQuestionaryAnswersRepository questionaryAnswersRepository)
        {
            _questionaryAnswersRepository = questionaryAnswersRepository;
        }

        public async Task AddVoice(QuestionaryAnswerModel answer)
        {
            answer.QuestionType = VoteTypeStringValue;
            answer.AnsweredCount = 1;
            await _questionaryAnswersRepository.AddAsync(
                Mapper.Map<QuestionaryAnswerModel, QuestionaryAnswer>(answer));
        }

        public async Task AddVoice(VoiceModel voice)
        {
            var qAnswer = new QuestionaryAnswerModel
            {
                QuestionType = VoteTypeStringValue,
                Answer = StringTechnologiesMathces[voice.Technology],
                AnsweredCount = 1
            };

            await _questionaryAnswersRepository.AddAsync(
                Mapper.Map<QuestionaryAnswerModel, QuestionaryAnswer>(qAnswer));
        }
    }
}