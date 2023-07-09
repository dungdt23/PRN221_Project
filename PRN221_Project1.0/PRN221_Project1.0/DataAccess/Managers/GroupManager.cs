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
    }
}
