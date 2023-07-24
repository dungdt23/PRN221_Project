using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Pages
{
    public class ViewAttendanceModel : PageModel
    {
        IGroupRepository _groupRepository;
        IStudentRepository _studentRepository;
        IAttendanceRepository _attendanceRepository;
        ISessionRepository _sessionRepository;
        public List<GroupDTO> Groups { get; set; }
        public List<StudentDTO> Students { get; set; }
        public Dictionary<string, float> AttendanceCheck { get; set; }
        public int groupId { get; set; }
        public List<AttendanceDTO> attendanceDetails { get; set; }
        public List<SessionDTO> sessionDetails { get; set; }
        public StudentDTO studentDetail { get; set; }
        public ViewAttendanceModel(IGroupRepository groupRepository, IStudentRepository studentRepository, IAttendanceRepository attendanceRepository, ISessionRepository sessionRepository)
        {
            _groupRepository = groupRepository;
            _studentRepository = studentRepository;
            _attendanceRepository = attendanceRepository;
            _sessionRepository = sessionRepository;
        }
        public IActionResult OnGet(int? groupId, string? studentId)
        {
            //get lecture 
            string json = HttpContext.Session.GetString("lecture");
            if (!string.IsNullOrEmpty(json))
            {
                LectureDTO lecture = JsonConvert.DeserializeObject<LectureDTO>(json);
                Groups = _groupRepository.GetGroups(lecture.LectureId);
                if (groupId.HasValue)
                {
                    this.groupId = groupId.Value;
                    Students = _studentRepository.GetStudents(groupId.Value);
                    AttendanceCheck = _attendanceRepository.GetAttendances(groupId.Value);
                    if (!string.IsNullOrEmpty(studentId))
                    {
                        sessionDetails = _sessionRepository.GetSessionsOfGroup(groupId.Value);
                        attendanceDetails = _attendanceRepository.GetAttendances(groupId.Value, studentId);
                        studentDetail = _studentRepository.GetStudent(studentId);
                    }
                }
                return Page();
            }
            else
            {
                // Redirect the user to the login page
                return RedirectToPage("/Login");
            }
        }
    }
}
