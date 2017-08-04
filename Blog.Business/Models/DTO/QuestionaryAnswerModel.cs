using Blog.Business.Models.DTO.Base;

namespace Blog.Business.Models.DTO
{
    public class QuestionaryAnswerModel : BaseModel
    {
        public string Answer { get; set; }
        public string QuestionType { get; set; }
        public int AnsweredCount { get; set; }
    }
}