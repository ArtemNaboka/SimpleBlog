namespace Blog.Models
{
    public class Questionary
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public string QuestionType { get; set; }
        public int AnsweredCount { get; set; }
    }
}