using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Models
{
    public class InstructorStudent
    {
        [Key]
        public int Id { get; set; }
        public virtual Student Students { get; set; }
        public virtual Instructor Instructors { get; set; }
    }
}
