using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Models
{
    public class Student : Person
    {
        public string Level { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<InstructorStudent> InstructorStudents { get; set; }

    }
}
