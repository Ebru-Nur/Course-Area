using CourseApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Infrastructure.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<CourseContent> CourseContents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User Configurations
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<int>();

            // Course Configurations
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Course)
                .HasForeignKey(o => o.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.CartItems)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);

            // Order Configurations
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasIndex(o => new { o.UserId, o.CourseId })
                .IsUnique();

            // Cart Configurations
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Course)
                .WithMany(c => c.CartItems)
                .HasForeignKey(c => c.CourseId);

            // Payment Configurations
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CourseContent>()
    .HasOne(c => c.Course)
    .WithMany(c => c.Contents)
    .HasForeignKey(c => c.CourseId);
        }
    }
}
