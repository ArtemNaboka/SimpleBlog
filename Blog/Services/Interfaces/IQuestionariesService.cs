﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Models.Entities;

namespace Blog.Services.Interfaces
{
    public interface IQuestionariesService
    {
        Task AddAsync(Questionary questionary);
        Task AddRangeAsync(IEnumerable<Questionary> questionaries);
        Task<QuestionaryResults> GetStatistics();
    }
}