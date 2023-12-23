using LectureAttendance.Models;
using LectureAttendance.Pages.Control.Update;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Delete
{
    public class D_LectureModel : PageModel
    {
        PContext db = new PContext();


        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string LectureLocation { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        [DataType(DataType.Date)]
        public string LectureDate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        [DataType(DataType.Time)]
        public string LectureStartTime { get; set; }


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

        public IQueryable<string> LectureStartTimeList()
        {
            var LectureStartTimeList = from l in db.Lectures where l.DateOfLecture == LectureDate select l.StartTime;
            return LectureStartTimeList;
        }
        
        public IQueryable<string> LectureLocationList()
        {
            var LectureLocationList = from l in db.Lectures where l.DateOfLecture == LectureDate select l.Location;
            return LectureLocationList;
        }


        public void OnPost()
        {
            if (Action == "Get")
            {
                if (ModelState.IsValid)
                {
                    var date = (from lec in db.Lectures where LectureDate == lec.DateOfLecture select lec.StartTime).FirstOrDefault();

                    if (date != null)
                    {


                        flag = true;

                    }
                    else
                    {
                        errorMessage = "Lecture Not Found!";
                        LectureDate = "";
                    }
                }
                else { errorMessage = "Error!"; }
            }
            else if (Action == "Delete")
            {
                Lecture lecture = new();
                lecture = (from l in db.Lectures where LectureDate==l.DateOfLecture && LectureStartTime == l.StartTime && LectureLocation == l.Location select l).FirstOrDefault();
                if (lecture != null)
                {
                    db.Lectures.Remove(lecture);
                    db.SaveChanges();
                    successMessage = "The Lecture Deleted Successfully!";

                    LectureDate = "";
                    LectureStartTime = "";
                    LectureLocation = "";

                    ModelState.Clear();
                }
                else
                {
                    errorMessage = "Error! No Lecture Matches These Inputs!";
                    flag = true;
                }
            }
        }
    }
}
