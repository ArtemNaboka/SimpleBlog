using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Business.Models.DTO;
using Blog.Business.Models.QuestionaryAnswerModels;

namespace Blog.Business.Services.Interfaces
{
    public interface IQuestionaryAnswersService : IService<QuestionaryAnswerModel>
    {
        Task CreateQuestionaryAsync(QuestionaryModel model);
        Task AddAsync(QuestionaryAnswerModel questionary);
        Task AddRangeAsync(IEnumerable<QuestionaryAnswerModel> questionaries);
        Task<QuestionaryResults> GetStatistics();
    }
}