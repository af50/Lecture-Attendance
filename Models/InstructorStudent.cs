using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureAttendance.Models
{
    public class InstructorStudent
    {
        [Required]
        public string InstructorId { get; set; }
        [Required]
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public virtual Student Students { get; set; }
        public virtual Instructor Instructors { get; set; }
    }
}
