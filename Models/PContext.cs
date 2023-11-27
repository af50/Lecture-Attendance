using Microsoft.EntityFrameworkCore;

namespace LectureAttendance.Models
{
    public class PContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CollegeDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public DbSet<Student> students {  get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
        public DbSet<InstructorStudent> instructorsStudents { get;set; }
    }
}
