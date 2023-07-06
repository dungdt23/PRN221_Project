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
    }
}
