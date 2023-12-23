using LectureAttendance.Migrations;
using LectureAttendance.Models;
using LectureAttendance.Pages.Control.Update;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LectureAttendance.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IQueryable<Lecture> LecturesList()
        {
            IQueryable<Lecture> lectures = null;
            if (HttpContext.Session.GetString("Type") == "Student")
            {
                PContext db = new PContext();
                var courses = from enrollment in db.Enrollments where enrollment.StudentId == HttpContext.Session.GetString("ID") select enrollment.CourseId;
                foreach (var course in courses)
                {
                    var lec = from lecture in db.Lectures where lecture.CourseId == course select lecture;
                    if (lectures != null)
                    {
                        lectures = lectures.Union(lec);
                    }
                    else
                    {
                        lectures = lec;
                    }
                }
            }
            return lectures;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Type") == null)
            {
                return RedirectToPage("/Login/Index");
            }
            else
            {
                LecturesList();
                return Page();
            }
        }
    }
}
