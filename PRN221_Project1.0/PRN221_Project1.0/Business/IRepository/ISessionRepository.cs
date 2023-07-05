using PRN221_Project1._0.Business.DTO;

namespace PRN221_Project1._0.Business.IRepository
{
    public interface ISessionRepository
    {
        List<SessionDTO> GetSessions(string lectureId, DateTime from, DateTime to);
    }
}
