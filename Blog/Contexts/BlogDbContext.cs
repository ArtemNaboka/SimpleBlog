﻿using System.Data.Entity;
using Blog.Models;

namespace Blog.Contexts
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}