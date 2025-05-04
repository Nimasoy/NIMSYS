using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Lending> Lendings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Book-Category
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            // Book-Tag many-to-many
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Tags)
                .WithMany(t => t.Books);

            // Book-Lending
            modelBuilder.Entity<Lending>()
                .HasOne(l => l.Book)
                .WithMany(b => b.Lendings)
                .HasForeignKey(l => l.BookId);

            // User-Lending
            modelBuilder.Entity<Lending>()
                .HasOne(l => l.User)
                .WithMany(u => u.BorrowedBooks)
                .HasForeignKey(l => l.UserId);

            // Book-Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reservations)
                .HasForeignKey(r => r.BookId);

            // User-Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId);
        }
    }
} 