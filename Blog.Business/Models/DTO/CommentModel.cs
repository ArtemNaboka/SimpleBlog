using System;
using Blog.Business.Models.DTO.Base;

namespace Blog.Business.Models.DTO
{
    public class CommentModel : BaseModel
    {
        public string AuthorName { get; set; }
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }
    }
}