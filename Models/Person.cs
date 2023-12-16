using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Models
{

    public class Person
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        public char Gender { get; set; }
    }
}
