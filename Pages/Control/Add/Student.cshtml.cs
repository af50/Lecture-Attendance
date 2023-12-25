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
        [RegularExpression(@"^1520[0-9]{5,6}$", ErrorMessage = "This Is An Invalid Student Id")]
        public string Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        [RegularExpression(@"^[a-zA-Z]+ [a-zA-Z]+ [a-zA-Z]+$", ErrorMessage = "The Name Should Looks Like --> \"Salem Khaled Salah\" With Out Quotes")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public char Level { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        [RegularExpression(@"^\w{5,20}\@attend\.std\.edu$", ErrorMessage = "The Email Should Looks Like \"example@attend.std.edu\" With Out Quotes")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        [RegularExpression(@"^[^ ]{8,12}$", ErrorMessage = "The Password Should have 8-12 Charcters With No Spaces")]
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

                try
                {
                    db.Students.Add(newStudent);
                    db.SaveChanges();
                    successMessage = "The Student Added Successfully!";
                } catch { errorMessage = "The Student ID Exists! Enter Another ID!"; }

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
                errorMessage = "Error! Check One Or More Inputs!";
                return;
            }
        }
    }
}
