using Microsoft.EntityFrameworkCore;
using MiniBlog.Core.Domain.Blog.Entities;
using MiniBlog.Core.Domain.Categories.Entities;
using MiniBlog.Core.Domain.Photos.Entities;
using System.Collections.Generic;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace MiniBlog.Infra.Data.Sql.Commands.Common
{
    public class MiniBlogCommandDbContext : BaseOutboxCommandDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogPhoto> BlogPhotos { get; set; }
        public MiniBlogCommandDbContext(DbContextOptions<MiniBlogCommandDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BlogPhoto>()
                .ToTable("BlogPhotos");
            modelBuilder.Entity<BlogCategory>()
                .ToTable("BlogCategories");
        }
    }
}
