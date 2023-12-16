using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureAttendance.Models
{
    public class Enrollment
    {
        [Required]
        public string CourseId { get; set; }
        [Required]
        public string StudentId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string EnrollmentDate { get; set; }
        [Required]
        public virtual Student Students { get; set; }
        public virtual Course Courses { get; set; }
    }
}
