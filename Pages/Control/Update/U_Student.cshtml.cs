using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Update
{
    public class U_StudentModel : PageModel
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

        //[BindProperty]
        //[Required(ErrorMessage = "This Field Is Required")]
        //public string Password { get; set; }

        [BindProperty]
        public string Phone { get; set; }


        [BindProperty]
        public string BirthDate { get; set; }

        [BindProperty]
        [Required]
        public char Gender { get; set; }


        public string errorMessage = "";
        public string successMessage = "";
        public bool flag = false;

        [BindProperty]
        public string parameter1 {  get; set; }


        public void OnPost()
        {
            if (parameter1 == "ID")
            {
                flag = true;

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

                }
                else
                {
                    errorMessage = "Student Not Found!";
                }
            }
            else
            {
                if (true)
                {
                    Student UpdatedStudent = new Student();

                    UpdatedStudent.StudentId = Id;
                    UpdatedStudent.Name = Name;
                    UpdatedStudent.Email = Email;
                    UpdatedStudent.Gender = Gender;
                    UpdatedStudent.Phone = Phone;
                    UpdatedStudent.Password = BCrypt.Net.BCrypt.HashPassword("tttt");
                    UpdatedStudent.DateOfBirth = BirthDate;
                    UpdatedStudent.Level = Level;

                    try
                    {
                        db.Students.Update(UpdatedStudent);
                        db.SaveChanges();
                    }
                    catch { errorMessage = "The Student ID Has Changed!"; }

                    successMessage = "The Student Updated Successfully!";

                    Id = "";
                    Name = "";
                    Email = "";
                    //Password = "";
                    Level = '\0';
                    Gender = '\0';
                    Phone = "";
                    BirthDate = "";
                    errorMessage = "";

                    ModelState.Clear();
                }
                else
                {
                    errorMessage = Id + Name +"    "+ Email + "    " + Level + "    " + Gender + "    " + Phone + "    " + BirthDate ;
                    //errorMessage = "Error!";
                    flag = false;
                }
            }
        }
    }
}
