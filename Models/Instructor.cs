using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Models
{
    public class Instructor : Person
    {
        public string Department { get; set; }
        
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<InstructorStudent> InstructorStudents { get; set; }
    }
}
