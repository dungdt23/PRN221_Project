using AutoMapper;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Managers;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.Repository
{
    public class SlotRepository : ISlotRepository
    {
        Prn221MyAssignmentContext _context;
        IMapper _mapper;
        SlotManager manager;
        public SlotRepository(Prn221MyAssignmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<SlotDTO> GetSlots()
        {
            manager = new SlotManager(_context);
            List<Slot> slots = manager.GetSlots();
            List<SlotDTO> slotDTOs = new List<SlotDTO>();
            slotDTOs = _mapper.Map<List<SlotDTO>>(slots);
            return slotDTOs;
        }
    }
}
