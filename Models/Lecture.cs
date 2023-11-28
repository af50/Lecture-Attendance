using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Models
{
    public class Lecture
    {
        [Key]
        public int LId { get; set; }
        public string Location { get; set; }
        public string DateOfLecture { get; set; }

        public virtual Instructor Instructors { get; set; }
        public virtual Course Courses { get; set; }
    }
}
