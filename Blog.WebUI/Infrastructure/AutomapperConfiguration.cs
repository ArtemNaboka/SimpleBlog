using AutoMapper;
using Blog.Business.Models.DTO;
using Blog.WebUI.ViewModels.ArticleViewModels;

namespace Blog.WebUI.Infrastructure
{
    public static class AutomapperConfiguration
    {
        public static void Configure()
        {            
            Mapper.Initialize(cfg =>
            {
                Business.Infrastructure.AutomapperConfiguration.Configure(cfg);
                cfg.CreateMap<ArticleModel, ArticleViewModel>().ReverseMap();
            });
        }
    }
}