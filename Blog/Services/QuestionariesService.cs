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

        public async Task CreateAsync(Questionary questionary)
        {
            await _questionariesRepository.AddAsync(questionary);
        }
    }
}