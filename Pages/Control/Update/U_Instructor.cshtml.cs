using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Update
{
    public class U_Instructor : PageModel
    {
        PContext db = new PContext();


        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string InstructorId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string Department { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
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


        public void OnPost()
        {
            if (Action == "Get")
            {
                Instructor ins = new();
                ins = db.Instructors.Find(InstructorId);

                if (ins != null)
                {
                    Name = ins.Name;
                    Email = ins.Email;
                    Phone = ins.Phone;
                    Gender = ins.Gender;
                    Department = ins.Department;
                    BirthDate = ins.DateOfBirth;
                    Password = "";

                    flag = true;
                }
                else
                {
                    errorMessage = "Instructor Not Found!";
                }
            }
            else if (Action == "Update")
            {
                if (ModelState.IsValid)
                {
                    Instructor UpdatedInstructor = new();

                    UpdatedInstructor.InstructorId = InstructorId;
                    UpdatedInstructor.Name = Name;
                    UpdatedInstructor.Email = Email;
                    UpdatedInstructor.Gender = Gender;
                    UpdatedInstructor.Phone = Phone;
                    UpdatedInstructor.Password = BCrypt.Net.BCrypt.HashPassword(Password);
                    UpdatedInstructor.DateOfBirth = BirthDate;
                    UpdatedInstructor.Department = Department;

                    try
                    {
                        db.Instructors.Update(UpdatedInstructor);
                        db.SaveChanges();
                    }
                    catch { errorMessage = "The Data Has Never Changed!"; }

                    successMessage = "The Instructor Updated Successfully!";

                    InstructorId = "";
                    Name = "";
                    Email = "";
                    Password = "";
                    Department = "";
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
