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
        public string CourseID { get; set; }

        public string errorMessage = "";
        public string successMessage = "";


        public void OnPost()
        {
            Course course = new();

            try
            {
                var CourseId = (from c in db.Courses where c.CourseId == CourseID select c.CourseId).Single();
                course.CourseId = CourseId;
                db.Courses.Remove(course);
                db.SaveChanges();
            }
            catch { errorMessage = "The Course ID You entered Is Not Found!"; }

            successMessage = "The Course Deleted Successfully!";

            CourseID = "";
            ModelState.Clear();
        }
    }
}
