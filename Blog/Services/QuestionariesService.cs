using System.Collections.Generic;
using System.Threading.Tasks;
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
    }
}