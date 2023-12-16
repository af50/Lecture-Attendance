using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Add
{
    public class LectureModel : PageModel
    {
        [Required]
        [BindProperty]
        public string Location { get; set; }
        [Required]
        [BindProperty]
        [DataType(DataType.Date)]
        public string DateOfLecture { get; set; }
        string now = DateTime.Now.ToString();
        [Required]
        [BindProperty]
        public string Instructor { get; set; }
        [Required]
        [BindProperty]
        public string Course { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {

            if (false) //DateOfLecture < now)
            {
                ErrorMessage = "Invalid Date!";
                return Page();
            }
            else
            {
                ErrorMessage = "Successfully added!";
                return Page();
            }
        }
    }
}