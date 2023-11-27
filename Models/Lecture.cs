using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Models
{
    public class Lecture
    {
        [Key]
        public virtual ICollection<Course> Courses { get; set; }
        [Key]
        public virtual ICollection<Instructor> Instuctors { get; set; }
        public string Location { get; set; }
        public string DateOfLecture { get; set; }

    }
}
