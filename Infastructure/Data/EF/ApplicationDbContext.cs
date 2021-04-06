using Core.Entities;
using Infastructure.Data.Entities;
using Infastructure.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructure.Data.EF
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookSubscription> BookSubscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.RenameIdentityTables();

            builder.Entity<Book>(ConfigureBook);
            builder.Entity<BookSubscription>(ConfigureBookSuscription);
        }
        private static void ConfigureBook(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book));
            builder.Property(_ => _.Name).IsRequired().HasColumnType("VARCHAR(100)");
            builder.Property(_ => _.Text).HasColumnType("VARCHAR(200)");
            builder.Property(_ => _.Price).IsRequired().HasColumnType("DECIMAL(9,2)");

            builder.SetDefaultConstraintForId();
            builder.HasData(
                new Book
                {
                    Name = "Clean Code: A Handbook of Agile Software Craftsmanship 1st Edition",
                    Price = 6000
                },
                new Book
                {
                    Name = "Code Complete: A Practical Handbook of Software Construction, Second Edition 2nd Edition",
                    Price = 7000
                },
                new Book
                {
                    Name = "Design Patterns: Elements of Reusable Object-Oriented Software 1st Edition",
                    Price = 11000
                },
                new Book
                {
                    Name = "Getting Started with Spring Boot",
                    Text = "Spring Boot cookbook",
                    Price = 10000
                },
                new Book
                {
                    Name = "Building Web Applications with Visual Studio 2017",
                    Price = 7000
                }
                );
        }
        private static void ConfigureBookSuscription(EntityTypeBuilder<BookSubscription> builder)
        {
            builder.ToTable(nameof(BookSubscription));
            builder.Property(_ => _.BookId).IsRequired();
            builder.Property(_ => _.UserId).IsRequired();
            builder.SetDefaultConstraintForId();
            builder.Property(_ => _.SubscriptionDate).IsRequired().HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()");

            builder.HasOne(_ => _.Book).WithMany().HasForeignKey(_ => _.BookId).HasConstraintName("FK_BookSubscription_BookId").OnDelete(DeleteBehavior.ClientCascade);
            //builder.HasOne(_ => _.User).WithMany().HasForeignKey(_ => _.UserId).HasConstraintName("FK_BookSubscription_UserId").OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
