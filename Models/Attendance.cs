using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Models
{
    public class Attendance
    {
        [Required]
        public string StudentID { get; set; }

        [Required]
        public string LecturesLocation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string LecturesDateOfLecture { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string LecturesStartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string LectureAttendanceTime { get; set; }

        public virtual Student Students { get; set; }
        public virtual Lecture Lectures { get; set; }
    }
}
