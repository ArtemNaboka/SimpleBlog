using System.Collections.Generic;
using Blog.Business.Models.DTO.Base;

namespace Blog.Business.Models.DTO
{
    public class TagModel : BaseModel
    {
        public string Name { get; set; }
        public IList<ArticleTagModel> ArticleTags { get; set; }
    }
}