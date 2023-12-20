using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Delete
{
    public class D_InstructorModel : PageModel
    {
        PContext db = new();

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required!")]
        public string InstructorID { get; set; }

        public string errorMessage = "";
        public string successMessage = "";


        public void OnPost()
        {
            Instructor instructor = new();

            try
            {
                var InstructorId = (from Ins in db.Instructors where Ins.InstructorId == InstructorID select Ins.InstructorId).Single();
                instructor.InstructorId = InstructorId;
                db.Instructors.Remove(instructor);
                db.SaveChanges();
            }
            catch { errorMessage = "The Instructor ID You Entered Is Not Found!"; }          

            successMessage = "The Instructor Deleted Successfully!";

            InstructorID = "";
            ModelState.Clear();
        }
    }
}
