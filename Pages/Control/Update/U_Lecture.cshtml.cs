using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LectureAttendance.Pages.Control.Update
{
    public class U_Lecture : PageModel
    {
        PContext db = new PContext();


        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string LectureLocation { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string LectureInstructor { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        public string LectureCourse { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        [DataType(DataType.Date)]
        public string LectureDate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        [DataType(DataType.Time)]
        public string LectureStartTime { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "This Field Is Required")]
        [DataType(DataType.Time)]
        public string LectureEndTime { get; set; }


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

        public IQueryable<string> CoursesList()
        {
            var CoursesList = from course in db.Courses select course.CourseName;
            return CoursesList;
        }


        public IQueryable<string> InstructorsList()
        {
            var InstructorsList = from instructor in db.Instructors select instructor.Name;
            return InstructorsList;
        }

        public void OnPost()
        {
            if (Action == "Get")
            {
                var lecture = (from lec in db.Lectures where LectureDate == lec.DateOfLecture
                            && LectureStartTime == lec.StartTime
                            && LectureLocation == lec.Location
                            select lec).FirstOrDefault();

                if (lecture != null)
                {
                    LectureEndTime =lecture.EndTime;
                    LectureCourse = lecture.CourseId;
                    LectureInstructor=lecture.InstructorId;

                    flag = true;

                }
                else
                {
                    errorMessage = "Lecture Not Found!";
                }
            }
            else if (Action == "Update")
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        Lecture lecture = new();
                        lecture.CourseId = (from Course in db.Courses where Course.CourseName == LectureCourse select Course.CourseId).Single(); ;
                        lecture.InstructorId = (from Instructor in db.Instructors where Instructor.InstructorId == LectureInstructor select Instructor.InstructorId).Single(); ;
                        lecture.Location = LectureLocation;
                        lecture.DateOfLecture = LectureDate;
                        lecture.StartTime = LectureStartTime;
                        lecture.EndTime = LectureEndTime;

                        db.Lectures.Update(lecture);
                        db.SaveChanges();
                        successMessage = "The Lecture Updated Successfully!";

                        LectureDate = "";
                        LectureStartTime = "";
                        LectureLocation = "";

                        ModelState.Clear();
                    } catch 
                    {
                        errorMessage = "Error!";
                        flag = true;
                    }
                }
                else
                {
                    errorMessage = "Error!";
                    flag = true;
                }
            }
        }
    }
}