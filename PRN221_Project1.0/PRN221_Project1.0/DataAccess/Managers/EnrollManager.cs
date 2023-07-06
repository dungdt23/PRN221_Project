using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class EnrollManager
    {
        Prn221MyAssignmentContext _context;
        public EnrollManager(Prn221MyAssignmentContext context)
        {
            _context = context;
        }
        public List<Enroll> GetEnrolls(int groupId)
        {
            try
            {
                List<Enroll> enrolls = _context.Enrolls.Where(s => s.GroupId == groupId).ToList();
                return enrolls;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
