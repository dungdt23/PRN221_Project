using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class RoomManager
    {
        Prn221MyAssignmentContext _context;
        public RoomManager(Prn221MyAssignmentContext prn221MyAssignmentContext)
        {
            _context = prn221MyAssignmentContext;
        }
        public List<Room> GetRooms()
        {
            return _context.Rooms.ToList();
        }
    }
}
