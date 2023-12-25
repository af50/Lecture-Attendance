using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Delete
{
    public class D_CourseModel : PageModel
    {
        PContext db = new();

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Requird!")]
        [RegularExpression(@"^[A-Z][A-Z][1-4][0-9][0-9]$", ErrorMessage = "The Course Id Should Consists Of Two Letters And Three Numbers")]
        public string CourseID { get; set; }

        public string errorMessage = "";
        public string successMessage = "";

		public IActionResult OnGet()
		{
			if (HttpContext.Session.GetString("Type") == null)
			{
				return RedirectToPage("/Login/Index");
			}
			if (HttpContext.Session.GetString("Type") == "Student")
			{
				return RedirectToPage("/Index");
			}
			else if (HttpContext.Session.GetString("Type") == "Instructor")
			{
				return RedirectToPage("/Index");
			}
			else
			{
				return Page();
			}
		}

		public void OnPost()
        {
            Course course = new();

            try
            {
                var CourseId = (from c in db.Courses where c.CourseId == CourseID select c.CourseId).SingleOrDefault();
                course.CourseId = CourseId;
                db.Courses.Remove(course);
                db.SaveChanges();
            }
            catch { errorMessage = "The Course ID You Entered Is Not Found!"; }

            successMessage = "The Course Deleted Successfully!";

            CourseID = "";
            ModelState.Clear();
        }
    }
}
