using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LectureAttendance.Models;
using System.ComponentModel.DataAnnotations;
namespace LectureAttendance.Pages.Control.Add
{
    public class StudentModel : PageModel
    {
        PContext db = new PContext();


        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public char Level { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string Password { get; set; }

        [BindProperty]
        public string Phone { get; set; }

        [BindProperty]
        public string BirthDate { get; set; }

        [BindProperty]
        [Required]
        public char Gender { get; set; }


        public string errorMessage = "";
        public string successMessage = "";

		public IActionResult OnGet()
		{
            if(HttpContext.Session.GetString("Type") == null)
            {
				return RedirectToPage("/Login/Index");
			}
			if (HttpContext.Session.GetString("Type") == "Student")
			{
                return RedirectToPage("/Index");
			}
            else if(HttpContext.Session.GetString("Type") == "Instructor")
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
                Student newStudent = new Student();
                newStudent.StudentId = Id;
                newStudent.Name = Name;
                newStudent.Email = Email;
                newStudent.Gender = Gender;
                newStudent.Phone = Phone;
                newStudent.Password = BCrypt.Net.BCrypt.HashPassword(Password);
                newStudent.DateOfBirth = BirthDate;
                newStudent.Level = Level;
                db.Students.Add(newStudent);
                db.SaveChanges();
                successMessage = "The Student Added Successfully!";

                Id = "";
                Name = "";
                Email = "";
                Password = "";
                Level = '\0';
                Gender = '\0';
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
