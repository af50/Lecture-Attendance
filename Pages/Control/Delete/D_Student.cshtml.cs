using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Delete
{
    public class StudentModel : PageModel
    {
        PContext db = new();

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required!")]
        public string StudentID { get; set; }

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
            Student student = new();

            try
            {
                var StudentId = (from Std in db.Students where Std.StudentId == StudentID select Std.StudentId).Single();
                student.StudentId = StudentId;
                db.Students.Remove(student);
                db.SaveChanges();
            }
            catch { errorMessage = "The Student ID You entered Is Not Found!"; }
                                     
            successMessage = "The Student Deleted Successfully!";

            StudentID = "";
            ModelState.Clear();
        }
    }
}
