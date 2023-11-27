using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Models
{
    public class Student 
    {
        [Key]
        public int SId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Level { get; set; }
        public string Phone { get; set;}
        public string DateOfBirth { get; set; } 
      


    }
}
