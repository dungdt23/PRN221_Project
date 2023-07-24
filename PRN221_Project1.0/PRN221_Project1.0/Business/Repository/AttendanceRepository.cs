using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Managers;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        Prn221MyAssignmentContext _context;
        IMapper _mapper;
        AttendanceManager manager;
        public AttendanceRepository(Prn221MyAssignmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<AttendanceDTO> GetAttendance(int sessionId)
        {
            manager = new AttendanceManager(_context);
            List<Attendance> attendances = manager.GetAttendance(sessionId);
            List<AttendanceDTO> attendanceDTOs = _mapper.Map<List<AttendanceDTO>>(attendances);
            return attendanceDTOs;

        }
        public void TakeAttendance(int attendanceId, bool status)
        {
            manager = new AttendanceManager(_context);
            manager.TakeAttendance(attendanceId, status);
        }
        public Dictionary<string, float> GetAttendances(int groupId)
        {
            manager = new AttendanceManager(_context);
            return manager.GetAttendances(groupId);
        }

        public void CreateAttendance(int sessionId)
        {
            manager = new AttendanceManager(_context);
            manager.CreateAttendance(sessionId);
        }
        public List<AttendanceDTO> GetAttendances(int groupId, string studentId)
        {
            manager = new AttendanceManager(_context);
            List<Attendance> attendances = manager.GetAttendances(groupId, studentId);
            List<AttendanceDTO> attendanceDTOs = _mapper.Map<List<AttendanceDTO>>(attendances);
            return attendanceDTOs;
        }
        public void UpdateRemoveAttendance(string studentId, int groupId)
        {
            manager = new AttendanceManager(_context);
            manager.UpdateRemoveAttendance(studentId, groupId);

        }
        public void UpdateAddAttendance(string studentId, int groupId)
        {
            manager = new AttendanceManager(_context);
            manager.UpdateAddAttendance(studentId, groupId);
        }

    }
}
