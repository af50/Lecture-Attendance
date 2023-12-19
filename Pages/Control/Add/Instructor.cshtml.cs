using LectureAttendance.Migrations;
using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Add
{
    public class InstructorModel : PageModel
    {

        [BindProperty]
        [Required(ErrorMessage = "This field is required")]
        public string Id { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "This field is required")]
        public string DepartInstructor { get; set; }
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
                Instructor newInstructor = new Instructor();
                newInstructor.InstructorId = Id;
                newInstructor.Name = Name;
                newInstructor.Phone = Phone;
                newInstructor.Email = Email;
                newInstructor.Password = BCrypt.Net.BCrypt.HashPassword(Password);
                newInstructor.DateOfBirth = BirthDate;
                newInstructor.Gender = Gender[0];
                newInstructor.Department = DepartInstructor;
                db.Instructors.Add(newInstructor);
                db.SaveChanges();
                successMessage = "The instructor added successfully!";
                Id = "";
                Name = "";
                Email = "";
                Password = "";
                DepartInstructor = "";
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