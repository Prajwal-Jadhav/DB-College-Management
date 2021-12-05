using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DB_College_Management.Data.Entity;

namespace DB_College_Management.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<Student>()
           .HasMany(s => s.Professors)
           .WithMany(p => p.Students);

           modelBuilder.Entity<Course>()
           .HasOne(c => c.Professor)
           .WithMany(p => p.Courses);

           modelBuilder.Entity<Professor>()
           .HasOne(p => p.Department)
           .WithMany(d => d.Professors);

           modelBuilder.Entity<Student>()
           .HasOne(s => s.Department)
           .WithMany(d => d.Students);

           modelBuilder.Entity<Course>()
           .HasOne(c => c.Department)
           .WithMany(d => d.Courses);

           modelBuilder.Entity<Course>()
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses);
       }
    }
}
