using Blog.Domain.Entities.Base;

namespace Blog.Domain.Entities
{
    public class QuestionaryAnswer : BaseEntity
    {
        public string Answer { get; set; }
        public string QuestionType { get; set; }
        public int AnsweredCount { get; set; }
    }
}