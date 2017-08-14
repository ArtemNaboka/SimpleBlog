using Blog.Business.Infrastructure;

namespace Blog.Business.Models.VoteModels
{
    public class VoteAnswerStatistics
    {
        public NetTechnologies Answer { get; set; }
        public int AnsweredCount { get; set; }
        public double AnsweredPercent { get; set; }
    }
}