using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
        public char Gender { get; set; }
    }
}
