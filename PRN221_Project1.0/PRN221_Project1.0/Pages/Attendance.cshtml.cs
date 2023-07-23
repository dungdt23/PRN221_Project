using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.Business.Repository;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Pages
{
    public class AttendanceModel : PageModel
    {
        IStudentRepository _studentRepository;
        IGroupRepository _groupRepository;
        IAttendanceRepository _attendanceRepository;
        ISessionRepository _sessionRepository;
        public List<StudentDTO> students;
        public List<AttendanceDTO> attendances { get; set; }

        public int? savedSessionId;
        public AttendanceModel(IStudentRepository studentRepository, IGroupRepository groupRepository, IAttendanceRepository attendanceRepository, ISessionRepository sessionRepository)
        {
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
            _attendanceRepository = attendanceRepository;
            _sessionRepository = sessionRepository;
        }
        public void OnGet(int? sessionId)
        {
            if (sessionId.HasValue)
            {
                GroupDTO group = _groupRepository.GetGroup(sessionId.Value);
                students = _studentRepository.GetStudents(group.GroupId);
                attendances = _attendanceRepository.GetAttendance(sessionId.Value);
                if (attendances.Count == 0)
                {
                    _attendanceRepository.CreateAttendance(sessionId.Value);
                    attendances = _attendanceRepository.GetAttendance(sessionId.Value);
                }
                savedSessionId = sessionId.Value;
            }
        }
        public IActionResult OnPost()
        {
            string sessionIdStr = Request.Form["sessionId"];
            int sessionId = Int32.Parse(sessionIdStr);
            if (sessionId != 0)
            {
                attendances = _attendanceRepository.GetAttendance(sessionId);
                foreach (AttendanceDTO a in attendances)
                {
                    bool status = true;

                    if (Request.Form["attendance[" + a.AttendanceId + "]"].Equals("false"))
                    {
                        status = false;
                    }
                    _attendanceRepository.TakeAttendance(a.AttendanceId, status);
                }
                _sessionRepository.TakeAttendance(sessionId);
            }

            return RedirectToPage("Timetable");
        }
    }
}
