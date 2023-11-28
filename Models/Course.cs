
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Models
{
    public class Course
    {
        [Key]
        public string CId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }




    }
}
