using Blog.Business.Models.DTO.Base;
using Blog.Domain.Entities;

namespace Blog.Business.Models.DTO
{
    public class ArticleTagModel : BaseModel
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }

        public Article Article { get; set; }
        public Tag Tag { get; set; }
    }
}