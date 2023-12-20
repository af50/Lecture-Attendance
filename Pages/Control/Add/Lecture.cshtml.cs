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
        public string CourseName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [BindProperty]
        public string InstructorName { get; set; }

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

   
        public IQueryable<string> CoursesList()
        {
            var CoursesList = from course in db.Courses select course.Name;
            return CoursesList;
        }


        public IQueryable<string> InstructorsList()
        {
            var InstructorsList = from instructor in db.Instructors select instructor.Name;
            return InstructorsList;
        }


        public void OnPost()
        {

            if (ModelState.IsValid)
            {
                Lecture lecture = new Lecture();
                
                lecture.CourseId = (from Course in db.Courses where Course.Name == CourseName select Course.CourseId).Single();
                lecture.InstructorId = (from Instructor in db.Instructors where Instructor.Name == InstructorName select Instructor.InstructorId).Single();
                lecture.Location = Location;
                lecture.DateOfLecture = DateOfLecture;
                lecture.StartTime= StartTime;
                lecture.EndTime = EndTime;
                
                try
                {
                    db.Add(lecture);
                    db.SaveChanges();
                }
                catch { errorMessage = "Cannot save! Check one or more inputs!"; }
                
                successMessage = "The lecture added successfully!";
                
                CourseName = "";
                InstructorName = "";
                Location = "";
                DateOfLecture = "";
                StartTime = "";
                EndTime = "";
                ModelState.Clear();
            }
            else
            {
                errorMessage = "There is something wrong!";
            }
        }
    }
}