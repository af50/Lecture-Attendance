using LectureAttendance.Migrations;
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
        public IQueryable<Lecture> WhichList { get; set; }

        public void StudentLecturesList()
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
            WhichList = lectures;
        }

        public void InstructorLecturesList()
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
            WhichList = InstructorLecturesList;
        }

        public void AdminLecturesList()
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
            WhichList = AdminLecturesList;
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
    }
}
