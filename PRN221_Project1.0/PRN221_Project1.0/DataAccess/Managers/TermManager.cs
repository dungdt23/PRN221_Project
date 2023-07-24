using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class TermManager
    {
        Prn221MyAssignmentContext _context;
        public TermManager(Prn221MyAssignmentContext context)
        {
            _context = context;
        }
        public List<Term> GetAllTerms()
        {
            return _context.Terms.ToList();
        }
    }
}
