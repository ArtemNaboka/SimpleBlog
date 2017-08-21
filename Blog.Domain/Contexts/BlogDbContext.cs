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
        public IDbSet<Tag> Tags { get; set; }
        public IDbSet<ArticleTag> ArticleTags { get; set; }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleTag>()
                .HasRequired(at => at.Article)
                .WithMany(a => a.ArticleTags)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ArticleTag>()
                .HasRequired(at => at.Tag)
                .WithMany(t => t.ArticleTags)
                .WillCascadeOnDelete();

            modelBuilder.Entity<UserRole>()
                .HasRequired(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .WillCascadeOnDelete();

            modelBuilder.Entity<UserRole>()
                .HasRequired(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .WillCascadeOnDelete();
        }
    }
}