using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Domain.Contexts.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Repositories.Base;
using Blog.Domain.Repositories.Interfaces;

namespace Blog.Domain.Repositories
{
    public class SqlQuestionaryAnswersRepository : GenericRepositoryBase<QuestionaryAnswer, int>,
        IQuestionaryAnswersRepository
    {
        public SqlQuestionaryAnswersRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public override async Task AddAsync(QuestionaryAnswer item)
        {
            var existingQuestionary = (await GetItemsAsync(qs =>
                qs.Where(q => q.Answer.Equals(item.Answer, StringComparison.InvariantCultureIgnoreCase)
                && q.QuestionType.Equals(item.QuestionType, StringComparison.InvariantCultureIgnoreCase))))
                .FirstOrDefault();

            if (existingQuestionary == null)
            {
                DbSet.Add(item);
                await BlogDbContext.SaveChangesAsync();
            }
            else
            {
                existingQuestionary.AnsweredCount++;
                await UpdateAsync(existingQuestionary);
            }
        }

        protected override Expression<Func<QuestionaryAnswer, bool>> KeyPredicate(int key) => (e => e.Id == key);
    }
}