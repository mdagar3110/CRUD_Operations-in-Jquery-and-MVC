using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;


namespace FluentAPI_Start.DAL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("Default")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(50).IsRequired().IsUnicode(false);

            modelBuilder.Entity<Product>().HasRequired(p => p.Category).WithMany().HasForeignKey(c => c.CatID);


           

            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<StudentDetails>().ToTable("StudentDetails");
            modelBuilder.Entity<StudentLogin>().ToTable("StudentLogin");
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        // public DbSet<Student> Student { get; set; }
        public DbSet<StudentDetails> StudentDetails { get; set; }
        public DbSet<StudentLogin> StudentLogin { get; set; }
    }
}