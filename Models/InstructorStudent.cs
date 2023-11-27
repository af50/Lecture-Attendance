using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Models
{
    public class InstructorStudent
    {
        [Key]
        public virtual ICollection<Student> Students { get; set; }
        [Key]
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}
