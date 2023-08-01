using Microsoft.EntityFrameworkCore;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class SessionManager
    {
        Prn221MyAssignmentContext _context;
        public SessionManager(Prn221MyAssignmentContext context)
        {
            _context = context;
        }
        public List<Session> GetSessions(string lectureId, DateTime from, DateTime to)
        {
            List<Session> sessions = new List<Session>();
            sessions = _context.Sessions
                                 .Where(s => s.Date >= from && s.Date <= to)
                                 .Include(s => (s as Session).Group)
                                 .ThenInclude(g => (g as Group).Course)
                                 .ThenInclude(c => (c as Course).Lecture)
                                 .Where(s => s.Group.Course.LectureId == lectureId)
                                 .Include(s => s.Room)
                                 .ToList();
            return sessions;
        }
        public void TakeAttendance(int sessionId)
        {
            Session session = _context.Sessions.FirstOrDefault(s => s.SessionId == sessionId);
            if (session != null)
            {
                session.IsAttended = true;
            }
            _context.SaveChanges();
        }
        public List<Session> AttendedSession(int groupId)
        {
            List<Session> sessions = new List<Session>();
            sessions = _context.Sessions.Where(s => s.GroupId == groupId && s.IsAttended == true)
                                     .ToList();
            return sessions;
        }
        public List<Session> GetSessionsOfGroup(int groupId)
        {
            List<Session> sessions = new List<Session>();
            sessions = _context.Sessions.Include(s => s.Room).Include(s => s.Slot).Where(s => s.GroupId == groupId).ToList();
            return sessions;
        }
        public bool CreateSession(int groupId, DateTime date, int slotId, int roomId, string lectureId)
        {
            Session session = new Session();
            session.GroupId = groupId;
            session.Date = date;
            session.SlotId = slotId;
            session.RoomId = roomId;
            session.IsAttended = false;
            if (isExisted(date, slotId, roomId, lectureId))
            {
                return false;
            }
            else
            {
                _context.Sessions.Add(session);
                _context.SaveChanges();
                return true;
            }
        }
        public bool isExisted(DateTime date, int slotId, int roomId, string lectureId)
        {
            List<Session> sessions = _context.Sessions.Where(s => s.SlotId == slotId && s.Date == date && s.RoomId == roomId)
                                                      .ToList();
            //List<Session> sessions1 = _context.Sessions
            //    .Include(s => s.Group)
            //    .ThenInclude(s => s.Course)
            //    .Where(s => s.SlotId == slotId && s.Date == date && s.Group.Course.LectureId.Equals(lectureId))
            //    .ToList();
            if (sessions == null || sessions.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
