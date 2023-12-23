using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Update
{
    public class U_Course : PageModel
    {
        PContext db = new PContext();


        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string CourseCode { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string CourseName { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public char CourseLevel { get; set; }


        
        public string errorMessage = "";
        public string successMessage = "";
        public bool flag = false;

        [BindProperty]
        public string Action { get; set;  }


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
            if (Action == "Get")
            {
                Course c = new();
                c = db.Courses.Find(CourseCode);

                if (c != null)
                {

                    CourseName = c.CourseName;
                    CourseLevel = c.RelatedLevel;
                    
                    flag = true;

                }
                else
                {
                    errorMessage = "Course Not Found!";
                }
            }
            else if (Action  == "Update")
            {
                if (ModelState.IsValid)
                {
                    Course UpdatedCourse = new();

                    UpdatedCourse.CourseId = CourseCode;
                    UpdatedCourse.CourseName = CourseName;
                    
                    try
                    {
                        db.Courses.Update(UpdatedCourse);
                        db.SaveChanges();
                        successMessage = "The Course Updated Successfully!";
                    }
                    catch { errorMessage = "The Data Has Never Changed!"; }

                    CourseCode = "";
                    CourseName = "";
                    CourseLevel = '\0';
                    
                    ModelState.Clear();
                }
                else
                {
                    errorMessage = "Error! Check One Or More Inputs!";
                    flag = true;
                }
            }
        }
    }
}
