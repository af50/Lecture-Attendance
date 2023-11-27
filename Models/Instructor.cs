using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Models
{
    public class Instructor
    {
        [Key]
        public string IId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }

    }
}
