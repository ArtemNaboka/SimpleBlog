using Blog.Domain.Entities.Base;

namespace Blog.Domain.Entities
{
    public class ArticleTag : BaseEntity
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }

        public Article Article { get; set; }
        public Tag Tag { get; set; }
    }
}