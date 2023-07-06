using Microsoft.EntityFrameworkCore;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class AttendanceManager
    {
        Prn221MyAssignmentContext _context;
        public AttendanceManager(Prn221MyAssignmentContext context)
        {
            _context = context;
        }
        public List<Attendance> GetAttendance(int sessionId)
        {
            return _context.Attendances.Where(s => s.SessionId == sessionId)
                                        .Include(s => s.Student)
                                        .ToList();
        }
    }
}
