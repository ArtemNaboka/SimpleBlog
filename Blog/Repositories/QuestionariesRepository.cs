using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Contexts;
using Blog.Models;
using Blog.Repositories.Base;
using Blog.Repositories.Interfaces;

namespace Blog.Repositories
{
    public class QuestionariesRepository : CrudRepositoryBase<Questionary, int>, IQuestionariesRepository
    {
        public QuestionariesRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task AddAsync(Questionary item)
        {
            var existingQuestionary = (await GetItemsAsync(qs =>
                qs.Where(q => q.Answer.Equals(item.QuestionType, StringComparison.InvariantCultureIgnoreCase) 
                && q.QuestionType.Equals(item.QuestionType, StringComparison.InvariantCultureIgnoreCase))))
                .SingleOrDefault();

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

        protected override Expression<Func<Questionary, bool>> KeyPredicate(int key) => (q => q.Id == key);
    }
}