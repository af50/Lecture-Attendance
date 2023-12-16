using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LectureAttendance.Models;
using System.ComponentModel.DataAnnotations;
namespace LectureAttendance.Pages.Control.Add
{
    public class StudentModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "This field is required")]
        public string Id { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "This field is required")]
        public string Level { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string BirthDate { get; set; }
        [BindProperty]
        [Required]
        public string Gender { get; set; }
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {

        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                PContext db = new PContext();
                Student newStudent = new Student();
                newStudent.StudentId = Id;
                newStudent.Name = Name;
                newStudent.Email = Email;
                newStudent.Gender = Gender[0];
                newStudent.Phone = Phone;
                newStudent.Password = BCrypt.Net.BCrypt.HashPassword(Password);
                newStudent.DateOfBirth = BirthDate;
                newStudent.Level = Level[0];
                db.Students.Add(newStudent);
                db.SaveChanges();
                successMessage = "The student added successfully!";
                Id = "";
                Name = "";
                Email = "";
                Password = "";
                Level = "";
                Gender = "";
                Phone = "";
                BirthDate = "";
                errorMessage = "";
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
