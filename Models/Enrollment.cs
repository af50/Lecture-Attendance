using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Models
{
    public class Enrollment
    {
        [Key] 
        public int Id { get; set; }
        public string EnrollmentDate { get; set; }  
        public string Instrcutor { get; set; }
        public virtual Student Students { get; set; }
        public virtual Course Courses { get; set; }
    }
}
