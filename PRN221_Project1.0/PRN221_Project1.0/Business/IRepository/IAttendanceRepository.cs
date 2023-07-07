using PRN221_Project1._0.Business.DTO;

namespace PRN221_Project1._0.Business.IRepository
{
    public interface IAttendanceRepository
    {
        List<AttendanceDTO> GetAttendance(int sessionId);
        void TakeAttendance(int attendanceId, bool status);
    }
}
