using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Business.Models.DTO;
using Blog.Business.Models.QuestionaryAnswerModels;
using Blog.Business.Models.VoteModels;

namespace Blog.Business.Services.Interfaces
{
    public interface IVoteService : IService<QuestionaryAnswerModel>
    {
        Task AddVoice(VoiceModel answer);
        Task<IEnumerable<VoteAnswerStatistics>> GetVoteResults();
    }
}