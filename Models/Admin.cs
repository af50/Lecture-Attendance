using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureAttendance.Models
{
    public class Admin : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AdminId { get; set; }
    }
}
