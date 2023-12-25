using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LectureAttendance.Pages.Login;

namespace LectureAttendance.Pages
{
    public class EnrollmentModel : PageModel
    {
        PContext db = new PContext();


        [BindProperty]
        public string SelectedCourseName { get; set; }


        public string successMessage = "";
        public string errorMessage = "";


        public IQueryable<string> CoursesList()
        {
            var CoursesList = from c in db.Courses where c.RelatedLevel == (HttpContext.Session.GetString("Level"))[0] select c.CourseName;
            return CoursesList;
        }

        public IActionResult OnGet(string ID, char Level)
        {
            if (HttpContext.Session.GetString("Type") == "Student")
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/Login/Index");
            }
        }

        
        public void OnPost()
        {
            Enrollment enrollment = new Enrollment();
            var CourseId = (string)(from c in db.Courses where c.CourseName == SelectedCourseName select c.CourseId).FirstOrDefault();
            if (CourseId != null)
            {
                enrollment.CourseId = CourseId;
                enrollment.StudentId = HttpContext.Session.GetString("ID");
                enrollment.EnrollmentDate = DateTime.Now.Date.ToString("yyyy-MM-dd");

                try
                {
                    db.Enrollments.Add(enrollment);
                    db.SaveChanges();
                    successMessage = "Register Done!";
                }
                catch { errorMessage = "Registered!"; }
            }
            else
            {
                return;
            }
        }
    }
}
