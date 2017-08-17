using System.Collections.Generic;
using Blog.Domain.Entities.Base;

namespace Blog.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public IList<ArticleTag> ArticleTags { get; set; }
    }
}