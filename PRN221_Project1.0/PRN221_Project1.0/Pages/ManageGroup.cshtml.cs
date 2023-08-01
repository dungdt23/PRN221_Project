using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Models;
using System.Text.RegularExpressions;
using Group = PRN221_Project1._0.DataAccess.Models.Group;

namespace PRN221_Project1._0.Pages
{
    public class ManageGroupModel : PageModel
    {
        public List<GroupDTO> groups { get; set; }
        public List<TermDTO> terms { get; set; }
        public List<LectureDTO> lectures { get; set; }
        public List<CourseDTO> courses { get; set; }
        public List<EnrollDTO> enrolls { get; set; }
        public List<StudentDTO> students { get; set; }
        IGroupRepository groupRepository;
        ILectureRepository lectureRepository;
        ITermRepository termRepository;
        ICourseRepository courseRepository;
        IEnrollRepository enrollRepository;
        IStudentRepository studentRepository;
        IAttendanceRepository attendanceRepository;
        public bool? isStarted { get; set; }
        public string? lectureIdFilter { get; set; }
        public int? termIdFilter { get; set; }
        public int? groupIdFilter { get; set; }
        public ManageGroupModel(IGroupRepository groupRepository, ILectureRepository lectureRepository, ITermRepository termRepository, ICourseRepository courseRepository, IEnrollRepository enrollRepository, IStudentRepository studentRepository, IAttendanceRepository attendanceRepository)
        {
            this.groupRepository = groupRepository;
            this.lectureRepository = lectureRepository;
            this.termRepository = termRepository;
            this.courseRepository = courseRepository;
            this.enrollRepository = enrollRepository;
            this.studentRepository = studentRepository;
            this.attendanceRepository = attendanceRepository;
        }
        public IActionResult OnGet(string? lectureIdFilter, int? termIdFilter, int? groupId)
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
            if (!string.IsNullOrEmpty(lectureIdFilter) || termIdFilter != null)
            {
                groups = groupRepository.GetGroupsByLectureTerm(lectureIdFilter, termIdFilter);
            }
            terms = termRepository.GetAllTerms();
            lectures = lectureRepository.GetAllLectures();
            courses = courseRepository.GetAllCourses(null, null, null, null);
            students = studentRepository.GetAllStudents();
            if (groupId.HasValue)
            {
                enrolls = enrollRepository.GetEnrolls(groupId.Value);
                bool isStarted = groupRepository.IsStarted(groupId.Value);
                this.isStarted = isStarted;
                if (isStarted)
                {
                    TempData["messageResponse"] = "This group has been started. You can't edit members";

                }
                else
                {
                    TempData["messageResponse"] = "You can edit members";

                }
            }
            this.lectureIdFilter = lectureIdFilter;
            this.termIdFilter = termIdFilter;
            groupIdFilter = groupId;
            return Page();

        }
        public IActionResult OnPostCreateGroup()
        {
            Group group = new Group();
            if (string.IsNullOrEmpty(HttpContext.Request.Form["groupName"]) || Int32.Parse(HttpContext.Request.Form["courseId"]) == null)
            {
                TempData["messageResponse"] = "Add fail";
                return RedirectToPage();
            }
            group.GroupName = HttpContext.Request.Form["groupName"];
            group.CourseId = Int32.Parse(HttpContext.Request.Form["courseId"]);
            groupRepository.CreateGroup(group);
            TempData["messageResponse"] = "Add success";
            return RedirectToPage();
        }
        public IActionResult OnPostCreateStudent()
        {
            string studentId = HttpContext.Request.Form["studentId"];
            string lectureId = HttpContext.Request.Form["lectureIdFilter"];
            string termId = HttpContext.Request.Form["termIdFilter"];
            int groupId = Int32.Parse(HttpContext.Request.Form["groupIdFilter"]);
            enrollRepository.AddEnroll(studentId, groupId);
            attendanceRepository.UpdateAddAttendance(studentId, groupId);
            //return RedirectToPage();
            return Redirect("/ManageGroup?lectureIdFilter=" + lectureId + "&termIdFilter=" + termId + "&groupId=" + groupId);

        }
        public IActionResult OnPostDeleteStudent(string studentId)
        {
            string lectureId = HttpContext.Request.Form["lectureIdFilter"];
            string termId = HttpContext.Request.Form["termIdFilter"];
            int groupId = Int32.Parse(HttpContext.Request.Form["groupIdFilter"]);
            attendanceRepository.UpdateRemoveAttendance(studentId, groupId);
            enrollRepository.RemoveEnroll(studentId, groupId);
            return Redirect("/ManageGroup?lectureIdFilter=" + lectureId + "&termIdFilter=" + termId + "&groupId=" + groupId);

        }
    }
}
