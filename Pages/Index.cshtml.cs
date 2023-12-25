using LectureAttendance.Models;
using LectureAttendance.Pages.Control.Update;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LectureAttendance.Pages
{
    public class IndexModel : PageModel
    {
        PContext db = new PContext();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public string Location { get; set; }

        [BindProperty]
        public string Date { get; set; }

        [BindProperty]
        public string StartTime { get; set; }

        public string errorMessage = "";
        public string successMessage = "";


        public IQueryable<Lecture> StudentLecturesList()
        {
            IQueryable<Lecture> lectures = null;
            if (HttpContext.Session.GetString("Type") == "Student")
            {  
                var courses = from enrollment in db.Enrollments where enrollment.StudentId == HttpContext.Session.GetString("ID") select enrollment.CourseId;
                foreach (var course in courses)
                {
                    var StudentLecturesList = from lecture in db.Lectures where lecture.CourseId == course select lecture;
                    if (!StudentLecturesList.IsNullOrEmpty())
                    {
                        foreach (var l in StudentLecturesList)
                        {
                            l.CourseId =  (from crse in db.Courses where l.CourseId == crse.CourseId select crse.CourseName).SingleOrDefault();
                            l.InstructorId = (from instructor in db.Instructors where l.InstructorId == instructor.InstructorId select instructor.Name).SingleOrDefault();
                        }
                        if (lectures != null)
                        {
                            lectures = lectures.Union(StudentLecturesList);
                        }
                        else
                        {
                            lectures = StudentLecturesList;
                        }
                    }
                }
            }
            return lectures;
        }

        public IQueryable<Lecture> InstructorLecturesList()
        {
            var InstructorLecturesList = from lec in db.Lectures where lec.InstructorId == HttpContext.Session.GetString("ID") select lec;
            if (!InstructorLecturesList.IsNullOrEmpty())
            {
                foreach (var l in InstructorLecturesList)
                {
                    l.CourseId = (from crse in db.Courses where l.CourseId == crse.CourseId select crse.CourseName).SingleOrDefault();
                    l.InstructorId = (from instructor in db.Instructors where l.InstructorId == instructor.InstructorId select instructor.Name).SingleOrDefault();
                }
            }
            return InstructorLecturesList;
        }

        public IQueryable<Lecture> AdminLecturesList()
        {
            var AdminLecturesList = from lec in db.Lectures select lec;
            if (!AdminLecturesList.IsNullOrEmpty())
            {
                foreach (var l in AdminLecturesList)
                {
                    l.CourseId = (from crse in db.Courses where l.CourseId == crse.CourseId select crse.CourseName).SingleOrDefault();
                    l.InstructorId = (from instructor in db.Instructors where l.InstructorId == instructor.InstructorId select instructor.Name).SingleOrDefault();
                }
            }
            return AdminLecturesList;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Type") == null)
            {
                return RedirectToPage("/Login/Index");
            }
            else if (HttpContext.Session.GetString("Type") == "Student")
            {
                StudentLecturesList();
                return Page();
            }
            else if (HttpContext.Session.GetString("Type") == "Instructor")
            {
                InstructorLecturesList();
                return Page();
            }
            else if (HttpContext.Session.GetString("Type") == "Admin")
            {
                AdminLecturesList();
                return Page();
            }
            else
            {
                return Page();
            }
        }

        [BindProperty]
        public string Action { get; set; }

        public IActionResult OnPost()
        {
            if (Action == "Start")
            {
                var lec = db.Lectures.FirstOrDefault(lecture => lecture.Location == Location
                && lecture.DateOfLecture == Date && lecture.StartTime == StartTime);
                if (lec != null && lec.IsStarted == false)
                {
                    lec.IsStarted = true;
                    db.SaveChanges();
                    successMessage = "The Lecture Has Been Started!";
                }
                else errorMessage = "The Lecture Is Starts Already!";
                return Page();
            }
            else if (Action == "End")
            {
                var lec = db.Lectures.FirstOrDefault(lecture => lecture.Location == Location
                && lecture.DateOfLecture == Date && lecture.StartTime == StartTime);
                if (lec != null && lec.IsStarted == true)
                {
                    lec.IsStarted = false;
                    db.SaveChanges();
                    successMessage = "The Lecture Has Been Ended!";
                }
                else errorMessage = "The Lecture Is Ended Already!";
                return Page();
            }
            else if (Action == "Report")
            {
                return RedirectToPage("/Report", new { location = Location, date = Date, startTime = StartTime });
            }
            else if (Action == "Register")
            {
                var lec = db.Lectures.FirstOrDefault(lecture => lecture.Location == Location
                && lecture.DateOfLecture == Date && lecture.StartTime == StartTime);
                if (lec.IsStarted)
                {
                    Attendance attendance = new Attendance();
                    attendance.StudentID = HttpContext.Session.GetString("ID");
                    attendance.LecturesLocation = Location;
                    attendance.LecturesDateOfLecture = Date;
                    attendance.LecturesStartTime = StartTime;
                    attendance.LectureAttendanceTime = DateTime.Now.TimeOfDay.ToString();

                    try
                    {
                        db.Attendances.Add(attendance);
                        db.SaveChanges();
                        successMessage = "Register Done!";
                    }
                    catch { errorMessage = "Registered!"; }
                }
                else errorMessage = "The Lecture Has Not Started Yet!";

                return Page();
            }
            else return Page();
        }
    }
}
