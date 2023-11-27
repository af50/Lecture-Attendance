using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Models
{
    public class Enrollment
    {
        [Key]
        public virtual ICollection<Course> Courses { get; set; }

        [Key]
        public virtual ICollection<Student> Students { get; set; }

        public string EnrollmentDate { get; set; }  

    }
}
