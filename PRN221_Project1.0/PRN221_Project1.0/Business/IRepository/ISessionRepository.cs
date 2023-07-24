using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.IRepository
{
    public interface ISessionRepository
    {
        List<SessionDTO> GetSessions(string lectureId, DateTime from, DateTime to);
        void TakeAttendance(int sessionId);
        List<SessionDTO> GetSessionsOfGroup(int groupId);
        bool CreateSession(int groupId, DateTime date, int slotId, int roomId);
    }
}
