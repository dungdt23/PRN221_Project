using Microsoft.EntityFrameworkCore;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class GroupManager
    {
        Prn221MyAssignmentContext _context;
        public GroupManager(Prn221MyAssignmentContext context)
        {
            _context = context;
        }
        //get group by sessionId
        public Group GetGroup(int sessionId)
        {
            try
            {
                Session session = _context.Sessions.FirstOrDefault(s => s.SessionId == sessionId);
                Group group = _context.Groups.FirstOrDefault(s => s.GroupId == session.GroupId);
                return group;
            }
            catch (Exception)
            {

                return null;
            }
        }
        //get groups by lectureId
        public List<Group> GetGroups(string lectureId)
        {
            List<Group> groups = new List<Group>();
            groups = _context.Groups.Include(s => s.Course)
                                    .Where(s => s.Course.LectureId.Equals(lectureId))
                                    .ToList();
            return groups;
        }

        //get groups by lectureId and termId
        public List<Group> GetGroupsByLectureTerm(string? lectureId, int? termId)
        {
            IQueryable<Group> query = _context.Groups.Include(s => s.Course)
                                                      .ThenInclude(s => s.Lecture)
                                                      .Include(s => s.Course)
                                                      .ThenInclude(s => s.Term);

            if (!string.IsNullOrEmpty(lectureId))
            {
                query = query.Where(s => s.Course.LectureId.Equals(lectureId));
            }
            if (termId != null)
            {
                query = query.Where(s => s.Course.TermId == termId);
            }

            return query.ToList();
        }
        public void CreateGroup(Group group)
        {
            _context.Groups.Add(group);
            _context.SaveChanges();
        }
        //check if group start 
        public bool IsStarted(int groupId)
        {
            List<Group> groups = _context.Groups.ToList();
            List<Session> sessions = _context.Sessions.Where(s => s.GroupId == groupId && s.IsAttended == true).ToList();
            if (sessions.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<Group> GetAllGroups()
        {
            return _context.Groups.Include(s => s.Course).ThenInclude(s => s.Lecture).ToList();
        }
    }
}
