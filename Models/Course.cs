
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureAttendance.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
