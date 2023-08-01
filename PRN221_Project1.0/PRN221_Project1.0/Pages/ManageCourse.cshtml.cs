using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Pages
{
    public class ManageCourseModel : PageModel
    {
        ICampusRepository campusRepository;
        ITermRepository termRepository;
        ISubjectRepository subjectRepository;
        ICourseRepository courseRepository;
        ILectureRepository lectureRepository;
        public List<CourseDTO> courses { get; set; }
        public List<LectureDTO> lectures { get; set; }
        public List<SubjectDTO> subjects { get; set; }
        public List<TermDTO> terms { get; set; }
        public List<CampusDTO> campuses { get; set; }
        public string? lectureIdFilter { get; set; }
        public int? subjectIdFilter { get; set; }
        public int? termIdFilter { get; set; }

        public int? campusIdFilter { get; set; }

        public ManageCourseModel(ICampusRepository campusRepository, ITermRepository termRepository, ISubjectRepository subjectRepository, ICourseRepository courseRepository, ILectureRepository lectureRepository)
        {
            this.campusRepository = campusRepository;
            this.termRepository = termRepository;
            this.subjectRepository = subjectRepository;
            this.courseRepository = courseRepository;
            this.lectureRepository = lectureRepository;
        }

        public IActionResult OnGet(string? lectureIdFilter, int? subjectIdFilter, int? termIdFilter, int? campusIdFilter)
        {
            string wsadmin = HttpContext.Session.GetString("admin");
            string json = HttpContext.Session.GetString("lecture");
            if (wsadmin == null && json == null)
            {
                // Redirect the user to the login page
                return RedirectToPage("/Login");
            }
            if (json != null)
            {
                return RedirectToPage("/Timetable");

            }
            courses = courseRepository.GetAllCourses(lectureIdFilter, subjectIdFilter, termIdFilter, campusIdFilter);
            lectures = lectureRepository.GetAllLectures();
            subjects = subjectRepository.GetAllSubjects();
            terms = termRepository.GetAllTerms();
            campuses = campusRepository.GetAllCampuses();
            this.lectureIdFilter = lectureIdFilter;
            this.subjectIdFilter = subjectIdFilter;
            this.termIdFilter = termIdFilter;
            this.campusIdFilter = campusIdFilter;
            return Page();
        }
        public IActionResult OnPostCreateCourse()
        {
            string courseName = HttpContext.Request.Form["courseName"];
            string courseCode = HttpContext.Request.Form["courseCode"];
            string lectureId = HttpContext.Request.Form["lectureId"];
            int subjectId = Int32.Parse(HttpContext.Request.Form["subjectId"]);
            int termId = Int32.Parse(HttpContext.Request.Form["termId"]);
            int campusId = Int32.Parse(HttpContext.Request.Form["campusId"]);
            Course course = new Course();
            course.CourseName = courseName;
            course.CourseCode = courseCode;
            course.LectureId = lectureId;
            course.SubjectId = subjectId;
            course.TermId = termId;
            course.CampusId = campusId;
            courseRepository.CreateCourse(course);
            return RedirectToPage();
        }
    }
}
