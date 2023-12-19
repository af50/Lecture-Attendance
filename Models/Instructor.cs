using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureAttendance.Models
{
    public class Instructor : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string InstructorId { get; set; }
        [Required]
        public string Department { get; set; }


        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<InstructorStudent> InstructorStudents { get; set; }
    }
}
