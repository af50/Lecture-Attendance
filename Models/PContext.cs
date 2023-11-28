using Microsoft.EntityFrameworkCore;

namespace LectureAttendance.Models
{
    public class PContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CollegeDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public DbSet<Student> Students {  get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<InstructorStudent> InstructorsStudents { get;set; }
    }
}
