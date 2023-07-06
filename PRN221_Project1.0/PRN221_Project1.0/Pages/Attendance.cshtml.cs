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
        public List<StudentDTO> students;
        public List<AttendanceDTO> attendances;
        public int? savedSessionId;
        public AttendanceModel(IStudentRepository studentRepository, IGroupRepository groupRepository, IAttendanceRepository attendanceRepository)
        {
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
            _attendanceRepository = attendanceRepository;
        }
        public void OnGet(int? sessionId)
        {
            if (sessionId.HasValue)
            {
                GroupDTO group = _groupRepository.GetGroup(sessionId.Value);
                students = _studentRepository.GetStudents(group.GroupId);
                attendances = _attendanceRepository.GetAttendance(sessionId.Value);
                savedSessionId = sessionId.Value;
            }
        }
        public IActionResult OnPost()
        {
            attendances = _attendanceRepository.GetAttendance(savedSessionId.Value);
            foreach (AttendanceDTO s in attendances)
            {
                // The value of s.IsAbsent has already been updated based on the selected radio button
                Console.WriteLine(s.IsAbsent);
                // No further action is needed in the code-behind file
            }
            return Page();
            return RedirectToPage("Timetable");
        }
    }
}
