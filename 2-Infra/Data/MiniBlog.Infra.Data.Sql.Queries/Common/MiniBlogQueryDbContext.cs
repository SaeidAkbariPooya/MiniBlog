using Microsoft.EntityFrameworkCore;
using MiniPerson.Infra.Data.Sql.Queries.Common;
using Zamin.Infra.Data.Sql.Queries;

namespace MiniBlog.Infra.Data.Sql.Queries.Common
{
    public partial class MiniBlogQueryDbContext : BaseQueryDbContext
    {
        public MiniBlogQueryDbContext(DbContextOptions<MiniBlogQueryDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Category> Categories { get; set; } 
        public virtual DbSet<Blog> Blogs { get; set; } 
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<BlogCategory> BlogCategories { get; set; }
        public virtual DbSet<BlogPhoto> BlogPhotos { get; set; }

        public virtual DbSet<OutBoxEventItem> OutBoxEventItems { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server =.; Database = MiniBlogDb;Integrated Security=True; MultipleActiveResultSets = true; Encrypt = false");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OutBoxEventItem>(entity =>
            {
                entity.Property(e => e.AccuredByUserId).HasMaxLength(255);

                entity.Property(e => e.AggregateName).HasMaxLength(255);

                entity.Property(e => e.AggregateTypeName).HasMaxLength(500);

                entity.Property(e => e.EventName).HasMaxLength(255);

                entity.Property(e => e.EventTypeName).HasMaxLength(500);
            });

            //modelBuilder.Entity<BusinessId>().OwnsOne(x => x.Value);

            modelBuilder.Entity<BlogPhoto>()
                .ToTable("BlogPhotos");
            modelBuilder.Entity<BlogCategory>()
                .ToTable("BlogCategories");

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
