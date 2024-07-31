using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineLearningAPI.Models;

public partial class OnlineLearningDbContext : DbContext
{
    //public OnlineLearningDbContext()
    //{
    //}

    public OnlineLearningDbContext(DbContextOptions<OnlineLearningDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseEnroll> CourseEnrolls { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentEnroll> StudentEnrolls { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=localhost;Database=OnlineLearningDB;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fees).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CourseEnroll>(entity =>
        {
            entity.HasKey(e => e.CourseId);

            entity.ToTable("CourseEnroll");

            entity.Property(e => e.CourseId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("CourseID");
            entity.Property(e => e.ContactNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Coordinator)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK_Student_1");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nic)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("NIC");
            entity.Property(e => e.Telephone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StudentEnroll>(entity =>
        {
            entity.HasKey(e => new { e.CourseId, e.StudentId });

            entity.ToTable("StudentEnroll");

            entity.Property(e => e.CourseId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("CourseID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("StudentID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(12)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
