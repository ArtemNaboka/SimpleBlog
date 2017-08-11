using System;
using Blog.Business.Models.DTO.Base;

namespace Blog.Business.Models.DTO
{
    public class ArticleModel : BaseModel
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }
        public string Tags { get; set; }
    }
}