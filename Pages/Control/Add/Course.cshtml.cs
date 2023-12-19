using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Add
{
    public class CourseModel : PageModel
    {


        [Required(ErrorMessage = "This field is required")]
        [BindProperty]
        public string Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [BindProperty]
        public string Name { get; set; }


        public string errorMessage = "";
        public string successMessage = "";
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                PContext db = new PContext();
                Course course = new Course();
                course.CourseId = Id;
                course.Name = Name;
                db.Add(course);
                db.SaveChanges();
                successMessage = "The student added successfully!";
                Id = "";
                Name = "";
                ModelState.Clear();
            }
            else
            {
                errorMessage = "There is something wrong.";
                return;
            }
        }
        } 
    }

