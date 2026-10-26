using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public class ContosoUniversityContext : DbContext
    {
        public ContosoUniversityContext (DbContextOptions<ContosoUniversityContext> options)
            : base(options)
        {
        }

        public DbSet<ContosoUniversity.Models.Student> Students { get; set; } = default!;
        public DbSet<ContosoUniversity.Models.Course> Courses { get; set; } = default!;
        public DbSet<ContosoUniversity.Models.Enrollment> Enrollments { get; set; } = default!;
        public DbSet<ContosoUniversity.Models.Instructor> Instructors { get; set; } = default!;
        public DbSet<ContosoUniversity.Models.Department> Departments { get; set; } = default!;
        public DbSet<ContosoUniversity.Models.OfficeAssignment> OfficeAssignments { get; set; } = default!;
        public DbSet<ContosoUniversity.Models.CourseAssignment> CourseAssignments { get; set; } = default!;




        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>().ToTable("Student");
        //    modelBuilder.Entity<Course>().ToTable("Course");
        //    modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OfficeAssignment>()
                .ToTable("OfficeAssignment");

            modelBuilder.Entity<CourseAssignment>()
                .ToTable("CourseAssignment");

            modelBuilder.Entity<Department>()
                .ToTable("Department");


            modelBuilder.Entity<Department>()
                .HasOne(department => department.Administrator)
                .WithMany()
                .HasForeignKey(department => department.InstructorID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
