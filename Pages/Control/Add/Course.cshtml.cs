using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Add
{
    public class CourseModel : PageModel
    {
        [Required]
        [BindProperty]
        public string CourseCode { get; set; }
        [Required]
        [BindProperty]
        public string CourseName { get; set; }
        public string ErrorMessage { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            PContext db = new PContext();
            if (db.Courses.SingleOrDefault(course => course.Name == CourseName) == null ||
                db.Courses.SingleOrDefault(course => course.CourseId == CourseCode) == null)
            {
                ErrorMessage = "Invalid Code or Name!";
                return Page();
            }
            else
            {
                ErrorMessage = "hello, world";
                return RedirectToPage("/Add/Course");
            }
        }
    }
}
