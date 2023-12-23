using Microsoft.EntityFrameworkCore;

namespace LectureAttendance.Models
{
    public class PContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LectureAttendance;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //M:M
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.CourseId, e.StudentId });
            //M:M
            modelBuilder.Entity<InstructorStudent>()
                .HasKey(e => new { e.StudentId, e.InstructorId });
            //Composite Key
            modelBuilder.Entity<Lecture>()
                .HasKey(e => new { e.Location, e.DateOfLecture, e.StartTime });
            //M:M
            modelBuilder.Entity<Attendance>()
                .HasKey(a => new { a.StudentID, a.LecturesLocation, a.LecturesDateOfLecture, a.LecturesStartTime });
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students {  get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<InstructorStudent> InstructorsStudents { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}
