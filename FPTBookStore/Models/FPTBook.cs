using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FPTBookStore.Models
{
    public partial class FPTBook : DbContext
    {
        public FPTBook()
            : base("name=FPTBook")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Embark> Embarks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.AuthorName)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.Story)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Embarks)
                .WithRequired(e => e.Author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.BookName)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Book>()
                .Property(e => e.Details)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.CoverImage)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Embarks)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Fullname)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Embark>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<Embark>()
                .Property(e => e.Postion)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Price)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.PublisherName)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.Phone)
                .IsUnicode(false);
        }
    }
}
