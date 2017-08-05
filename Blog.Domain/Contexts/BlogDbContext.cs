using System.Data.Entity;
using Blog.Domain.Contexts.Interfaces;
using Blog.Domain.Entities;

namespace Blog.Domain.Contexts
{
    public class BlogDbContext : DbContext, IDbContext
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Database=BlogDB;Integrated Security=True";

        public BlogDbContext() : base(ConnectionString)
        {
            
        }

        public IDbSet<Article> Articles { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<QuestionaryAnswer> QuestionaryAnswers { get; set; }
    }
}