using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class CampusManager
    {
        Prn221MyAssignmentContext _context;
        public CampusManager(Prn221MyAssignmentContext context)
        {
            _context = context;
        }
        public List<Campus> GetAllCampuses()
        {
            return _context.Campuses.ToList();
        }
    }
}
