using System.ComponentModel.DataAnnotations.Schema;
using Blog.Domain.Entities.Base;

namespace Blog.Domain.Entities
{
    /// <summary>
    /// The class representing a single answer to a questionary.
    /// Example: City (question type) - New York (answer) - 20 (people chose this answer)
    /// </summary>

    [Table("Questionaries")]
    public class QuestionaryAnswer : BaseEntity
    {
        public string Answer { get; set; }
        public string QuestionType { get; set; }
        public int AnsweredCount { get; set; }
    }
}