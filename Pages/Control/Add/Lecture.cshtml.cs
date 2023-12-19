using LectureAttendance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Http;
using System.ComponentModel.DataAnnotations;


namespace LectureAttendance.Pages.Control.Add
{
    public class LectureModel : PageModel
    {
        PContext db = new PContext();


        [Required(ErrorMessage = "This field is required")]
        [BindProperty]
        public string CName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [BindProperty]
        public string IName { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [BindProperty]
        public string Location { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [BindProperty]
        [DataType(DataType.Date)]
        public string DateOfLecture { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [BindProperty]
        [DataType(DataType.Time)]
        public string StartTime { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [BindProperty]
        [DataType(DataType.Time)]
        public string EndTime { get; set; }



        public string errorMessage = "";
        public string successMessage = "";

   
        public IQueryable<string> Instructors { get; set; }
        public IQueryable<string> Courses { get; set; }



        public IQueryable<string> CoursesList()
        {

            var CList = from course in db.Courses select course.Name;
            return Courses = CList;

                      
        }

        public IQueryable<string> InstructorsList()
        {
            var IList = from instructor in db.Instructors select instructor.Name;
            return Instructors = IList;
        }

    



        public void OnPost()
        {

            if (ModelState.IsValid)
            {
                successMessage = "The lecture added successfully!";
                Lecture lecture = new Lecture();
                try
                {
                    lecture.CourseId = (from Course in db.Courses where Course.Name == CName select Course.CourseId).Single();
                    lecture.InstructorId = (from Instructor in db.Instructors where Instructor.Name == IName select Instructor.InstructorId).Single();
                }
                catch { errorMessage = "Course or Instructor cannot found!"; }
                lecture.Location = Location;
                lecture.DateOfLecture = DateOfLecture;
                lecture.StartTime= StartTime;
                lecture.EndTime = EndTime;
                db.Add(lecture);
                try
                {
                    db.SaveChanges();
                }
                catch { errorMessage = "Cannot save! Check one or more inputs!"; }
                successMessage = "The lecture added successfully!";
                CName = "";
                IName = "";
                Location = "";
                DateOfLecture = "";
                StartTime = "";
                EndTime = "";
                ModelState.Clear();
            }
            else
            {
                errorMessage = "There is something wrong!";
                return;
            }
        }
    }
}