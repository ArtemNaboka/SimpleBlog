﻿using AutoMapper;
using Blog.Business.Models.DTO;
using Blog.Business.Models.QuestionaryAnswerModels;
using Blog.Business.Models.VoteModels;
using Blog.WebUI.ViewModels.ArticleViewModels;
using Blog.WebUI.ViewModels.CommentViewModels;
using Blog.WebUI.ViewModels.QuestionariesViewModels;
using Blog.WebUI.ViewModels.VoteViewModels;

namespace Blog.WebUI.Infrastructure
{
    public static class AutomapperConfiguration
    {
        public static void Configure()
        {            
            Mapper.Initialize(cfg =>
            {
                Business.Infrastructure.AutomapperConfiguration.Configure(cfg);
                cfg.CreateMap<ArticleModel, CreateArticleViewModel>().ReverseMap();
                cfg.CreateMap<ArticleModel, ArticleViewModel>().ReverseMap();
                cfg.CreateMap<CommentModel, CommentViewModel>().ReverseMap();
                cfg.CreateMap<QuestionaryResults, QuestionaryResultsViewModel>();
                cfg.CreateMap<FillingQuestionaryViewModel, QuestionaryModel>()
                    .ForMember(q => q.AgeRange, x => x.MapFrom(f => f.AgeRange.Value))
                    .ForMember(q => q.HowLongReadBlog, x => x.MapFrom(f => f.HowLongReadBlog.Value))
                    .ForMember(q => q.Interestings, x => x.MapFrom(f => f.Interestings.InterestingsValues));
                cfg.CreateMap<CreateVoiceViewModel, VoiceModel>()
                    .ForMember(v => v.Technology, x => x.MapFrom(v => v.Answer));
            });
        }
    }
}