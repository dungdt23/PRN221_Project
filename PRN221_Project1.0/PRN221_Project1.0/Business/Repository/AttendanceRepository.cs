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
    }
}
