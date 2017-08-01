using System.Data.Entity;
using Blog.Models;
using Blog.Models.Entities;

namespace Blog.Contexts
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Questionary> Questionaries { get; set; }
    }


    public class BlogDbContextInitializer : DropCreateDatabaseAlways<BlogDbContext>
    {
        protected override void Seed(BlogDbContext dbContext)
        {
            
        }
    }
}