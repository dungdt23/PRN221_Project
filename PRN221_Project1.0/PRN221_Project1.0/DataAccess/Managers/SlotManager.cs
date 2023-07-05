using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.DataAccess.Managers
{
    public class SlotManager
    {
        Prn221MyAssignmentContext _context;
        public SlotManager(Prn221MyAssignmentContext context)
        {
            _context = context;
        }
        public List<Slot> GetSlots()
        {
            return _context.Slots.ToList();
        }
    }
}
