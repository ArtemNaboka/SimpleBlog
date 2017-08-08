namespace Blog.WebUI.ViewModels.QuestionariesViewModels
{
    public class QuestionaryViewModel
    {
        public FillingQuestionaryViewModel FillingQuestionary { get; set; } = new FillingQuestionaryViewModel();
        public bool UserHasFilled { get; set; }
        public QuestionaryResultsViewModel QuestionaryResults { get; set; }
    }
}