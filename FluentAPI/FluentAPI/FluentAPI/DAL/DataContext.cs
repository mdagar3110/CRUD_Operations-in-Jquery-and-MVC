using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
namespace FluentAPI.DAL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => new { u.UserId, u.Name });
            modelBuilder.Entity<User>().Property(p => p.Name).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Address).HasColumnType("varchar");

            modelBuilder.Entity<User>().ToTable("tblUser");

            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<Order>().Property(p => p.Name).HasMaxLength(50).IsUnicode(false).IsRequired();

            modelBuilder.Entity<User>().HasRequired(u => u.Order).WithMany().HasForeignKey(u => u.OrdId).WillCascadeOnDelete(true);
        }

        public DbSet<User> User { get; set; }
    }
}