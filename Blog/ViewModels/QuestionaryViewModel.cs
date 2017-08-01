using Blog.Models;

namespace Blog.ViewModels
{
    public class QuestionaryViewModel
    {
        public FillingQuestionaryViewModel FillingQuestionary { get; set; } = new FillingQuestionaryViewModel();
        public bool UserHasFilled { get; set; }
        public QuestionaryResults QuestionaryResults { get; set; }
    }
}