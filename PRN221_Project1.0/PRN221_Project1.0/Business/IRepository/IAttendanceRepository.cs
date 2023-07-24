using PRN221_Project1._0.Business.DTO;

namespace PRN221_Project1._0.Business.IRepository
{
    public interface IAttendanceRepository
    {
        List<AttendanceDTO> GetAttendance(int sessionId);
        void TakeAttendance(int attendanceId, bool status);
        Dictionary<string, float> GetAttendances(int groupId);
        void CreateAttendance(int sessionId);
        List<AttendanceDTO> GetAttendances(int groupId, string studentId);
        void UpdateRemoveAttendance(string studentId, int groupId);
        void UpdateAddAttendance(string studentId, int groupId);
    }
}
