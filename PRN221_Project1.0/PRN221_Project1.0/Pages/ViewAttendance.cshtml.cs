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
        public List<GroupDTO> Groups { get; set; }
        public List<StudentDTO> Students { get; set; }
        public Dictionary<string, float> AttendanceCheck { get; set; }
        public ViewAttendanceModel(IGroupRepository groupRepository, IStudentRepository studentRepository, IAttendanceRepository attendanceRepository)
        {
            _groupRepository = groupRepository;
            _studentRepository = studentRepository;
            _attendanceRepository = attendanceRepository;
        }
        public void OnGet(int? groupId)
        {
            //get lecture 
            string json = HttpContext.Session.GetString("lecture");
            if (!string.IsNullOrEmpty(json))
            {
                LectureDTO lecture = JsonConvert.DeserializeObject<LectureDTO>(json);
                Groups = _groupRepository.GetGroups(lecture.LectureId);
                if (groupId.HasValue)
                {
                    Students = _studentRepository.GetStudents(groupId.Value);
                    AttendanceCheck = _attendanceRepository.GetAttendances(groupId.Value);
                }
            }
        }
    }
}
