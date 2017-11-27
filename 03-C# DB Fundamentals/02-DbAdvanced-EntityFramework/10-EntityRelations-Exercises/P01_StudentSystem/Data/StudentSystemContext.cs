using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext() { }

        public StudentSystemContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(student =>
            {
                student.HasKey(s => s.StudentId);
                student.Property(s => s.Name).HasMaxLength(100).IsUnicode(true);
                student.Property(s => s.PhoneNumber).HasColumnType("char(10)").IsUnicode(false).IsRequired(false);
                student.Property(s => s.Birthday).IsRequired(false);
                student.HasMany(s => s.CourseEnrollments).WithOne(sc => sc.Student).HasForeignKey(sc => sc.StudentId);
                student.HasMany(s => s.HomeworkSubmissions).WithOne(h => h.Student).HasForeignKey(h => h.StudentId);
            });

            modelBuilder.Entity<Course>(course =>
            {
                course.HasKey(c => c.CourseId);
                course.Property(c => c.Name).HasMaxLength(80).IsUnicode(true);
                course.Property(c => c.Description).IsUnicode(true).IsRequired(false);
                course.HasMany(c => c.StudentsEnrolled).WithOne(sc => sc.Course).HasForeignKey(sc => sc.CourseId);
                course.HasMany(c => c.Resources).WithOne(r => r.Course).HasForeignKey(r => r.CourseId);
                course.HasMany(c => c.HomeworkSubmissions).WithOne(h => h.Course).HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<Resource>(resource =>
            {
                resource.HasKey(r => r.ResourceId);
                resource.Property(r => r.Name).HasMaxLength(50).IsUnicode(true);
                resource.Property(r => r.Url).IsUnicode(false);
            });

            modelBuilder.Entity<Homework>(homework => 
            {
                homework.HasKey(h => h.HomeworkId);
                homework.Property(h => h.Content).IsUnicode(false);
            });

            modelBuilder.Entity<StudentCourse>(studentCourse =>
            {
                studentCourse.HasKey(sc => new { sc.StudentId, sc.CourseId });
            });
        }
    }
}
