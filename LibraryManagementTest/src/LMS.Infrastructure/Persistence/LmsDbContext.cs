using System.Collections.Generic;
using System.Reflection.Emit;
using LMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Persistence
{
    public class LmsDbContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>();

        public LmsDbContext(DbContextOptions<LmsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(b => b.Title)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(b => b.Author)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(b => b.BookState)
                      .HasConversion<string>()
                      .IsRequired();
            });
        }
    }
}
