using Microsoft.EntityFrameworkCore;
using BookshelfWebApplication.Models;

namespace BookshelfWebApplication.Models
{
    public class BookshelfAPIContext : DbContext
    {
        
        public BookshelfAPIContext(DbContextOptions<BookshelfAPIContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorPublication> AuthorPublicationss { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Встановлюємо налаштування для таблиці Authors
            modelBuilder.Entity<Author>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Author>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Author>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Встановлюємо налаштування для таблиці AuthorPublication
            modelBuilder.Entity<AuthorPublication>()
                .HasKey(ap => ap.Id);
            modelBuilder.Entity<AuthorPublication>()
                .Property(ap => ap.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<AuthorPublication>()
                .HasOne(ap => ap.Author)
                .WithMany(a => a.AuthorPublications)
                .HasForeignKey(ap => ap.AuthorId);
            modelBuilder.Entity<AuthorPublication>()
                .HasOne(ap => ap.Publication)
                .WithMany(p => p.AuthorPublications)
                .HasForeignKey(ap => ap.PublicationId);

            // Встановлюємо налаштування для таблиці Categories
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Встановлюємо налаштування для таблиці Publications
            modelBuilder.Entity<Publication>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Publication>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Publication>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<Publication>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Publications);

            // Встановлюємо налаштування для таблиці Reviews
            modelBuilder.Entity<Review>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<Review>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Review>()
                .Property(r => r.Text)
                .IsRequired()
                .HasMaxLength(500);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Publication)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.PublicationId);

            // Встановлюємо налаштування для таблиці Tags
            modelBuilder.Entity<Tag>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Tag>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Tag>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
