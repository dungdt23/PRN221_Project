using AutoMapper;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Managers;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.Repository
{
    public class SessionRepository : ISessionRepository
    {
        Prn221MyAssignmentContext _context;
        IMapper _mapper;
        SessionManager manager;
        public SessionRepository(Prn221MyAssignmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SessionDTO> GetSessions(string lectureId, DateTime from, DateTime to)
        {
            manager = new SessionManager(_context);
            List<Session> sessions = manager.GetSessions(lectureId, from, to);
            List<SessionDTO> sessionDTOs = new List<SessionDTO>();
            sessionDTOs = _mapper.Map<List<SessionDTO>>(sessions);
            return sessionDTOs;
        }

        public List<SessionDTO> GetSessionsOfGroup(int groupId)
        {
            manager = new SessionManager(_context);
            List<Session> sessions = manager.GetSessionsOfGroup(groupId);
            List<SessionDTO> sessionDTOs = new List<SessionDTO>();
            sessionDTOs = _mapper.Map<List<SessionDTO>>(sessions);
            return sessionDTOs;
        }

        public void TakeAttendance(int sessionId)
        {
            manager = new SessionManager(_context);
            manager.TakeAttendance(sessionId);
        }
        public bool CreateSession(int groupId, DateTime date, int slotId, int roomId, string lectureId)
        {
            manager = new SessionManager(_context);
            return manager.CreateSession(groupId, date, slotId, roomId, lectureId);
        }


    }
}
