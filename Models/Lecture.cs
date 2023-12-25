using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureAttendance.Models
{
    public class Lecture
    {
        [Required]
        public string CourseId { get; set; }

        [Required]
        public string InstructorId { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string DateOfLecture { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string EndTime{ get; set; }

        [Required]
        public bool IsStarted { get; set; } = false;


        public virtual Instructor Instructors { get; set; }
        public virtual Course Courses { get; set; }
    }
}
