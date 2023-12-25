using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace LectureAttendance.Pages
{
    public class ReportModel : PageModel
    {
        PContext db = new();

        [BindProperty]
        public string Location { get; set; }

        [BindProperty]
        public string Date { get; set; }

        [BindProperty]
        public string StartTime { get; set; }

        [BindProperty]
        public string StudentID { get; set; }


        public List<string> SNames { get; set; }

        public string errorMessage = "";
        public string successMessage = "";

        public IActionResult OnGet(string location, string date, string startTime)
        {
            if (HttpContext.Session.GetString("Type") == null)
            {
                return RedirectToPage("/Login/Index");
            }
            else if (HttpContext.Session.GetString("Type") == "Student")
            {
                return Page();
            }
            else if (HttpContext.Session.GetString("Type") == "Instructor")
            {
                Location = location;
                Date = date;
                StartTime = startTime;
                return Page();
            }
            else if (HttpContext.Session.GetString("Type") == "Admin")
            {
                Location = location;
                Date = date;
                StartTime = startTime;
                return Page();
            }
            else
            {
                return Page();
            }
        }

        public IQueryable<Attendance> LectureAttendanceList()
        {
            var LectureAttendanceList = from lec in db.Attendances where lec.LecturesLocation == Location
                                        && lec.LecturesStartTime == StartTime && lec.LecturesDateOfLecture == Date select lec;
            if (!LectureAttendanceList.IsNullOrEmpty())
            {
                List<string> StudentNames = new List<string>();

                foreach (var l in LectureAttendanceList)
                {
                    var StudentName = (from std in db.Students where std.StudentId == l.StudentID select std.Name).SingleOrDefault();
                    StudentNames.Add(StudentName);
                }

                SNames = StudentNames;
            }
            return LectureAttendanceList;
        }


        public IActionResult OnPost()
        {
            var del = (from attendance in db.Attendances where attendance.LecturesLocation == Location
                      && attendance.LecturesDateOfLecture == Date && attendance.LecturesStartTime == StartTime
                      && attendance.StudentID == StudentID select attendance).SingleOrDefault();
            if (del != null)
            {
                db.Attendances.Remove(del);
                db.SaveChanges();
                return Page();
            }
            else return Page();
        }
    }
}
