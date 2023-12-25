using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Login
{
    public class IndexModel : PageModel
    {
        [Required]
        [BindProperty]
        public string Email { get; set; }
        [Required]
        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
        public IActionResult OnPost()
        {
            PContext db = new PContext();
            var Admin = from admin in db.Admins where admin.Email == Email select admin;
            var Instructor = from instructor in db.Instructors where instructor.Email == Email select instructor;
            var Student = from student in db.Students where student.Email == Email select student;
            if(!Student.IsNullOrEmpty() && Password != null && BCrypt.Net.BCrypt.Verify(Password,Student.SingleOrDefault().Password))
            {
                HttpContext.Session.SetString("Type", "Student");
                HttpContext.Session.SetString("ID", Student.SingleOrDefault().StudentId);
                HttpContext.Session.SetString("Email", Student.SingleOrDefault().Email);
                HttpContext.Session.SetString("Level", Convert.ToString(Student.FirstOrDefault().Level));
                return RedirectToPage("/Index");
            }         
            else if(!Admin.IsNullOrEmpty() && Password != null && BCrypt.Net.BCrypt.Verify(Password, Admin.SingleOrDefault().Password))
            {
				HttpContext.Session.SetString("Type", "Admin");
                HttpContext.Session.SetString("ID", Admin.SingleOrDefault().AdminId);
                HttpContext.Session.SetString("Email", Admin.SingleOrDefault().Email);
                return RedirectToPage("/Index");
			}
			else if (!Instructor.IsNullOrEmpty() && Password != null && BCrypt.Net.BCrypt.Verify(Password, Instructor.SingleOrDefault().Password))
			{
				HttpContext.Session.SetString("Type", "Instructor");
                HttpContext.Session.SetString("ID", Instructor.SingleOrDefault().InstructorId);
                HttpContext.Session.SetString("Email", Instructor.SingleOrDefault().Email);
                return RedirectToPage("/Index");
            }
			else
            {
                ErrorMessage = "Invalid Email Or Password!";
                return Page();
            }
        }
    }
}
