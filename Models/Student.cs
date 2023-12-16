using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureAttendance.Models
{
    public class Student : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string StudentId { get; set; }
        [Required]
        public char Level { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<InstructorStudent> InstructorStudents { get; set; }
    }
}
