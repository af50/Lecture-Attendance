using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Update
{
    public class U_Student : PageModel
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
        [Required(ErrorMessage = "This Field Is Required")]
        public string Phone { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string BirthDate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public char Gender { get; set; }


        public string errorMessage = "";
        public string successMessage = "";
        public bool flag = false;

        [BindProperty]
        public string Action { get; set; }

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
                Student std = new Student();
                std = db.Students.Find(Id);

                if (std != null)
                {
                    Name = std.Name;
                    Email = std.Email;
                    Phone = std.Phone;
                    Gender = std.Gender;
                    Level = std.Level;
                    BirthDate = std.DateOfBirth;
                    Password = "";

                    flag = true;
                }
                else
                {
                    errorMessage = "Student Not Found!";
                }
            }
            else if (Action  == "Update")
            {
                if (ModelState.IsValid)
                {
                    Student UpdatedStudent = new Student();

                    UpdatedStudent.StudentId = Id;
                    UpdatedStudent.Name = Name;
                    UpdatedStudent.Email = Email;
                    UpdatedStudent.Gender = Gender;
                    UpdatedStudent.Phone = Phone;
                    UpdatedStudent.Password = BCrypt.Net.BCrypt.HashPassword(Password);
                    UpdatedStudent.DateOfBirth = BirthDate;
                    UpdatedStudent.Level = Level;

                    try
                    {
                        db.Students.Update(UpdatedStudent);
                        db.SaveChanges();
                    }
                    catch { errorMessage = "The Data Has Never Changed!"; }

                    successMessage = "The Student Updated Successfully!";

                    Id = "";
                    Name = "";
                    Email = "";
                    Password = "";
                    Level = '\0';
                    Gender = '\0';
                    Phone = "";
                    BirthDate = "";

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
