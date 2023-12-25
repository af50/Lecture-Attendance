using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Add
{
    public class InstructorModel : PageModel
    {
        PContext db = new PContext();

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        [RegularExpression(@"^[0-9]{14}$", ErrorMessage = "The Id Should Equals The Instructor's SSN")]
        public string Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        [RegularExpression(@"^[a-zA-Z]+ [a-zA-Z]$", ErrorMessage = "The Name Should Looks Like --> \"Salem Khaled\" With Out Quotes")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        [RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "The Department Name Should Consists Of Two Upper Letters")]
        public string Depart { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        [RegularExpression(@"^\w{5,20}\@attend\.ins\.edu$", ErrorMessage = "The Email Should Looks Like \"example@attend.ins.edu\" With Out Quotes")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        [RegularExpression(@"^[^ ]{8,12}$", ErrorMessage = "The Password Should have 8-12 Charcters With No Spaces")]
        public string Password { get; set; }

        [BindProperty]
        public string Phone { get; set; }

        [BindProperty]
        public string BirthDate { get; set; }

        [Required]
        [BindProperty]
        public string Gender { get; set; }


        public string errorMessage = "";
        public string successMessage = "";

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

            if (ModelState.IsValid)
            {
                Instructor newInstructor = new Instructor();

                newInstructor.InstructorId = Id;
                newInstructor.Name = Name;
                newInstructor.Phone = Phone;
                newInstructor.Email = Email;
                newInstructor.Password = BCrypt.Net.BCrypt.HashPassword(Password);
                newInstructor.DateOfBirth = BirthDate;
                newInstructor.Gender = Gender[0];
                newInstructor.Department = Depart;

                try
                {
                    db.Instructors.Add(newInstructor);
                    db.SaveChanges();
                    successMessage = "The Instructor Added Successfully!";
                }
                catch { errorMessage = "The Instructor ID Exists! Enter Another ID!"; }


                Id = "";
                Name = "";
                Email = "";
                Password = "";
                Depart = "";
                Gender = "";
                Phone = "";
                BirthDate = "";
                errorMessage = "";

                ModelState.Clear();
            }
            else
            {
                errorMessage = "Error! Check One Or More Inputs!";
            }
        }

    }
}