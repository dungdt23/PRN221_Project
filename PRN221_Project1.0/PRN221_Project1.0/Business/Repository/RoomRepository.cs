using AutoMapper;
using PRN221_Project1._0.Business.DTO;
using PRN221_Project1._0.Business.IRepository;
using PRN221_Project1._0.DataAccess.Managers;
using PRN221_Project1._0.DataAccess.Models;

namespace PRN221_Project1._0.Business.Repository
{
    public class RoomRepository : IRoomRepository
    {
        Prn221MyAssignmentContext _context;
        IMapper _mapper;
        RoomManager manager;
        public RoomRepository(Prn221MyAssignmentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<RoomDTO> GetRooms()
        {
            manager = new RoomManager(_context);
            List<Room> rooms = manager.GetRooms();
            List<RoomDTO> roomDTOs = _mapper.Map<List<RoomDTO>>(rooms);
            return roomDTOs;
        }

    }
}
