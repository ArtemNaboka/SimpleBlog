using System.ComponentModel.DataAnnotations.Schema;
using Blog.Domain.Entities.Base;

namespace Blog.Domain.Entities
{
    [Table("Questionaries")]
    public class QuestionaryAnswer : BaseEntity
    {
        public string Answer { get; set; }
        public string QuestionType { get; set; }
        public int AnsweredCount { get; set; }
    }
}