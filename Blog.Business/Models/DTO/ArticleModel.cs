﻿using System;
using System.Collections.Generic;
using Blog.Business.Models.DTO.Base;

namespace Blog.Business.Models.DTO
{
    public class ArticleModel : BaseModel
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }

        public IList<ArticleTagModel> ArticleTags { get; set; }
    }
}