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

        public string ID {get; set;}
        public char Level {get; set;}

        public string ErrorMessage { get; set; }
        public IActionResult OnPost()
        {
            PContext db = new PContext();
            var Student = from student in db.Students where student.Email == Email select student;
            var Instructor = from instructor in db.Instructors where instructor.Email == Email select instructor;
            var Admin = from admin in db.Admins where admin.Email == Email select admin;
            if(!Student.IsNullOrEmpty() && Password!=null && BCrypt.Net.BCrypt.Verify(Password,Student.FirstOrDefault().Password))
            {
                HttpContext.Session.SetString("Type", "Student");
                HttpContext.Session.SetString("ID", Student.SingleOrDefault().StudentId);
                HttpContext.Session.SetString("Email", Student.SingleOrDefault().Email);
                HttpContext.Session.SetString("Level", Convert.ToString(Student.FirstOrDefault().Level));
                return RedirectToPage("/Index");
            }         
            else if(!Admin.IsNullOrEmpty() && Password != null && BCrypt.Net.BCrypt.Verify(Password, Admin.FirstOrDefault().Password))
            {
				HttpContext.Session.SetString("Type", "Admin");
                HttpContext.Session.SetString("ID", Admin.SingleOrDefault().AdminId);
                HttpContext.Session.SetString("Email", Admin.SingleOrDefault().Email);
                return RedirectToPage("/Control/Add/Student");
			}
			else if (!Instructor.IsNullOrEmpty() && Password != null && BCrypt.Net.BCrypt.Verify(Password, Instructor.FirstOrDefault().Password))
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
