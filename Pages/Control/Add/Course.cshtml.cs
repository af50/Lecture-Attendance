using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Add
{
    public class CourseModel : PageModel
    {


        [Required(ErrorMessage = "This Field Is Required")]
        [BindProperty]
        public string CourseID { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [BindProperty]
        public string CourseName { get; set; }
        
        [Required(ErrorMessage = "This Field Is Required")]
        [BindProperty]
        public char CourseLevel { get; set; }


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
            if (ModelState.IsValid)
            {
                PContext db = new PContext();
                Course course = new Course();
                course.CourseId = CourseID;
                course.CourseName = CourseName;
                course.RelatedLevel = CourseLevel;
                
                try
                {
                    db.Add(course);
                    db.SaveChanges();
                    successMessage = "The Course Added Successfully!";
                }
                catch { errorMessage = "The Course Code Exists! Enter Another Code!"; }
                

                CourseID = "";
                CourseName = "";
                CourseLevel = '\0';

                ModelState.Clear();
            }
            else
            {
                errorMessage = "Error! Check One Or More Inputs!";
            }
        }
    } 
}

