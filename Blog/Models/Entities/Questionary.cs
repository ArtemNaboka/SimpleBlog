using Blog.Models.Entities.Base;

namespace Blog.Models.Entities
{
    public class Questionary : BaseEntity
    {
        public string Answer { get; set; }
        public string QuestionType { get; set; }
        public int AnsweredCount { get; set; }
    }
}