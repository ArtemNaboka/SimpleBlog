using AutoMapper;
using Blog.Business.Models.DTO;
using Blog.Domain.Entities;

namespace Blog.Business.Infrastructure
{
    public static class AutomapperConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Article, ArticleModel>().ReverseMap();
            cfg.CreateMap<Comment, CommentModel>().ReverseMap();
        }
    }
}