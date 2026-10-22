using Academy.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy.Data;

public class AcademyContext : DbContext
{
    public AcademyContext(DbContextOptions<AcademyContext> options)
        : base(options)
    {
    }

    public DbSet<Discipline> Disciplines => Set<Discipline>();
    public DbSet<Direction> Directions => Set<Direction>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Discipline>(entity =>
        {
            entity.ToTable("Disciplines");
            entity.HasKey(e => e.DisciplineId).HasName("PK_Disciplines");

            entity.Property(e => e.DisciplineId)
                .ValueGeneratedOnAdd()
                .HasColumnName("discipline_id");
            entity.Property(e => e.DisciplineName)
                .HasMaxLength(150)
                .HasColumnName("discipline_name");
            entity.Property(e => e.NumberOfLessons)
                .HasColumnName("number_of_lessons");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.ToTable("Directions");
            entity.HasKey(e => e.DirectionId).HasName("PK_Directions");

            entity.Property(e => e.DirectionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("direction_id");
            entity.Property(e => e.DirectionName)
                .HasMaxLength(50)
                .HasColumnName("direction_name");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("Groups");
            entity.HasKey(e => e.GroupId).HasName("PK_Groups");

            entity.Property(e => e.GroupId)
                .ValueGeneratedOnAdd()
                .HasColumnName("group_id");
            entity.Property(e => e.GroupName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("group_name");
            entity.Property(e => e.DirectionId)
                .HasColumnName("direction");
            entity.Property(e => e.StartDate)
                .HasColumnName("start_date")
                .HasColumnType("date");
            entity.Property(e => e.StartTime)
                .HasColumnName("start_time")
                .HasColumnType("time(0)");
            entity.Property(e => e.LearningDays)
                .HasColumnName("learning_days");

            entity.HasOne(e => e.Direction)
                .WithMany(e => e.Groups)
                .HasForeignKey(e => e.DirectionId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Groups_Directions");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Students");
            entity.HasKey(e => e.StudentId).HasName("PK_Students");

            entity.Property(e => e.StudentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("stud_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.BirthDate)
                .HasColumnName("birth_date")
                .HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.Photo)
                .HasColumnName("photo")
                .HasColumnType("image");
            entity.Property(e => e.GroupId)
                .HasColumnName("group");

            entity.HasOne(e => e.Group)
                .WithMany(e => e.Students)
                .HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Students_Groups");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("Teachers");
            entity.HasKey(e => e.TeacherId).HasName("PK_Teachers");

            entity.Property(e => e.TeacherId)
                .ValueGeneratedOnAdd()
                .HasColumnName("teacher_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.BirthDate)
                .HasColumnName("birth_date")
                .HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.Photo)
                .HasColumnName("photo")
                .HasColumnType("image");
            entity.Property(e => e.WorkSince)
                .HasColumnName("work_since")
                .HasColumnType("date");
            entity.Property(e => e.Rate)
                .HasColumnName("rate")
                .HasColumnType("smallmoney");
        });
    }
}
