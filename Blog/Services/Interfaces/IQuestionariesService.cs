using System.Threading.Tasks;
using Blog.Models;

namespace Blog.Services.Interfaces
{
    public interface IQuestionariesService
    {
        Task CreateAsync(Questionary questionary);
    }
}